#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <openssl/rand.h>

#define LINE_SIZE 300

/*
 * Generates a random unsigned integer between 0 and max by using OpenSSL's
 * RAND_bytes (see man page).
 */
unsigned int random_uint(unsigned int max)
{
        union {
                unsigned int i;
                unsigned char c[sizeof(unsigned int)];
        } u;

        do {
                if (!RAND_bytes(u.c, sizeof(u.c))) {
                        fprintf(stderr, "Can't get random bytes\n");
                        exit(1);
                }
        } while (u.i < (-max % max));
        return u.i % max;
}

int main(int argc, char **argv)
{
	/**
	 * Try to open the file containing the example text.
	 * If the file cannot be found or any other error occurs, print
	 * 'File not found' and return -1.
	 */
	FILE *file;
	file = fopen("Muster.txt", "r");
	if (!file)
	{
		printf("File not found\n");
		return -1;
	}

	/**
	 * Allocate memory for each line to be read.
	 */
	char *linebuf = malloc(LINE_SIZE);
	if (linebuf == NULL)
	{
		printf("Could not allocate memory for buffer\n");
		return -1;
	}

	/** 
	 * fgets reads a line from
	 * a stream (which in this case is file) with the maximum size of
	 * LINE_SIZE-1 and puts it into our line buffer (linebuf).
	 */
	while (fgets(linebuf, LINE_SIZE, file) != NULL)
	{
		bool first = true;
		for (int i = 0; i < sizeof(linebuf)/sizeof(char*); i++)
		{
			/*if (first == true) 
			{ 
				first = false;
				continue;
			}*/
			int rand_num = random_uint(2);
			printf("%d\n", rand_num);
			if (rand_num == 1)
			{
				strcpy(&linebuf[i][i], &linebuf[i]+32);
			}
		}
	}
	printf("%s\n", linebuf);

	return 0;
}
