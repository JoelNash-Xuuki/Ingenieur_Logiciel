#include "Test.h"
#include "Dollar.h"
#include <assert.h>

Test::Test(){}
void Test::testMultiplication(){
    Dollar five(5);
    five.times(2);
    five.getAmount();
    assert(10 == five.getAmount());
}
