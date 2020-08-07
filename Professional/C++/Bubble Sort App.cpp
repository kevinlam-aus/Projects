//******************************************************************
// Grocery List
//
// The program creates a string array of the a shopping list of
//vitems and sort them using the bubble sort.
//******************************************************************

#include <iostream>
#include <cstring>
using namespace std;

void sortArray(string [], int);
void showArray(string [], int);

int main()
{
    const int SIZE = 9;

    string shoppingList[SIZE] = {"eggplant", "squash", "apples", "hamburger", "pizza", "shampoo", "soap", "laundry detergent", "bacon"};

    cout << "The unsorted values are:\n";
    showArray(shoppingList, SIZE);

    sortArray(shoppingList, SIZE);

    cout << "The sorted values are:\n";
    showArray(shoppingList, SIZE);
    return 0;
}



void sortArray(string array[], int size)
{
    string temp;
    bool swap;

    do
    {
        swap = false;
        for (int count = 0; count < (size - 1); count++)
        {
            if (array[count] > array[count + 1])
            {
                temp = array[count];
                array[count] = array[count + 1];
                array[count + 1] = temp;
                swap = true;
            }
        }
    }
    while (swap);
}




void showArray(string array[], int size)
{
    for (int count = 0; count < size; count++)
        cout << array[count] << " ";
    cout << endl;
}
