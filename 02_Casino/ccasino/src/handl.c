#include <stdlib.h>
#include <stdio.h>

void handle_startb(char* line_buf)
{
	printf("%s", line_buf);
	get_val_port(line_buf, &money_curr, sizeof(START_BUDGET_STR));
}
