#include <stdio.h>

/* Interger square root, using 1 + 3 + 5 + ... + 2*i-1 = i*i */
int iroot(int a){
    int i, term, sum;
	
    term=1; sum=1;
    for (i = 0; sum <= a; i++) {
	term=term+2;
	sum=sum+term;
    }
    return i;
}

int main(){
    printf("Square root: %i \n", iroot(-2));

    return 0;
}

