/*
 * Michael Koeppl 5AHIF
 * Casino simulation using config file
 */
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <inttypes.h>
#include <string.h>
#include <ctype.h>
#include <openssl/rand.h>

/* printed to inform the user about how to use this application */
const char USAGE_STRING[] = "Usage ./casino <path>";
/* 
 * predefined string that starts a line in the config file for defining the
 * user's start budget.
 */
const char START_BUDGET_STR[] = "Startguthaben";

/* predefined string that ends the config file. */
const char END_STR[] = "ENDE";

/* enum to differentiate between different input types */
enum input_type
{
	EVEN, /* even number in config file */
	ODD, /* odd number in config file */
	EXACT, /* exact number in config file */
	END, /* end of config file */
	START_BUDGET, /* start budget definition in config file */
	STR /* every other kind of string that is not one of the above */
};

/* File to be read from */
FILE *file;

/* Current amount of money */
int32_t money_curr;
/* The player's name */
char* p_name;

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

/* get input type of current line */
enum input_type get_input_type(const char *line_buf)
{
	if (strncmp(line_buf, START_BUDGET_STR, strlen(START_BUDGET_STR)) == 0) {
		return START_BUDGET;
	} else if (strncmp(line_buf, END_STR, strlen(END_STR)) == 0) {
		return END;
	}
	switch (line_buf[0]) {
		case 'G':
			return EVEN;
		case 'U':
			return ODD;
		default:
			if (isdigit(line_buf[0])) {
				return EXACT;
			}
			else {
				return STR;
			}
	}
}

/* 
 * Fetches part stating actual amount of money from start budget string, copies
 * it to a separate array, converts it to int32_t and stores it in dest
 */
void get_val_port(const char *line_buf, int32_t* dest, int32_t len)
{
	char am_buf[sizeof(line_buf)-len];
	memcpy(am_buf, &line_buf[len], sizeof(&am_buf)-1); 
	sscanf(am_buf, "%"SCNd32, dest);
}

/* Tries to withdraw amount from money_curr */
void wdraw(int32_t* amount)
{
	money_curr -= *amount;
	if (money_curr < 0) {
		fprintf(stderr, "Player %s doesn't have any money left.\n", p_name);
		exit(1);
	}
}

/* Handles starting entries */
void start(char* line_buf)
{
	get_val_port(line_buf, &money_curr, sizeof(START_BUDGET_STR));
	printf("Start budget: %d Euros\n", money_curr);
}

/* Handle guesses for even numbers */
void even(char* line_buf, int *number, int *val)
{
	printf("Even guess: %s", line_buf);
	get_val_port(line_buf, val, strlen("G "));
	wdraw(val);
	if (*number != 0 && *number % 2 == 0) {
		*val = *val * 2;
		money_curr += *val;
		printf("Player %s guess an even number (%d)\n", p_name, *number);
		printf("and won %d Euros.\n\n", *val);
	}
}

/* Handle guesses for odd numbers */
void odd(char* line_buf, int* number, int* val)
{
	printf("Odd guess: %s", line_buf);
	get_val_port(line_buf, val, strlen("U "));
	wdraw(val);
	if (*number % 2 != 0) {
		*val = *val * 2;
		money_curr += *val;
		printf("Player %s guessed an odd number (%d)\n",
		       p_name, *number);
		printf("and won %d Euros.\n\n", *val);
	}
}

/* Handles exact guesses for numbers */
void exact(char* line_buf, int* number, int* val)
{
	printf("Exact guess: %s", line_buf);
	get_val_port(line_buf, val, 2);
	wdraw(val);
	int32_t ex;
	sscanf(&line_buf[0], "%"SCNd32, &ex);
	if (ex == *number) {
		*val = *val * 7;
		money_curr += *val;
		printf("Wow! Player %s guessed the exact right number (%d)\n",
		       p_name, *number);
		printf("and won %d Euros.\n\n", *val);
	}
}

/* Handles end event */
void end()
{
	printf("\nThat's it, folks!\nPlayer %s has a total of %d Euros.\n",
	       p_name, money_curr);
}

/* 
 * Gets the players name from the given line buffer by removing the endline
 * character
 */
void get_name(char* line_buf)
{
	/* remove \n */
	p_name = malloc(sizeof(line_buf));
	memcpy(p_name, &line_buf[0], sizeof(&p_name)+1);
	strtok(p_name, "\n");
}

/* A single game loop step */
void step(char *line_buf)
{
	int number = random_uint(7+1);
	int32_t val;
	switch(get_input_type(line_buf)) {
		case START_BUDGET:
			start(line_buf);
			break;
		case EVEN:
			even(line_buf, &number, &val);
			break;
		case ODD:
			odd(line_buf, &number, &val);
			break;
		case EXACT:
			exact(line_buf, &number, &val);
			break;
		case END:
			end();
			break;
		case STR:
			get_name(line_buf);
			printf("Player %s playing...\n", p_name);
			break;
	}

}

int main(int argc, char **argv)
{
	if (argc <= 1) {
		printf("%s\n", USAGE_STRING);
		return -1;
	}

	file = fopen(argv[1], "r");
	char line_buf[255];
	while(fgets(line_buf, sizeof(line_buf), file) != NULL) {
		step(line_buf);
	}
	return 0;
}
