#include "Dollar.h"

Dollar::Dollar(int a) :amount{a}{}

int Dollar::getAmount() {return amount;}

void Dollar::times(int multiplier) {
    amount = amount * multiplier;
}
