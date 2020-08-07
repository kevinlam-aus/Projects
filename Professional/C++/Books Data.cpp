//******************************************************************
// Books Data
//
// The program asks the user how many students were surveyed and dynamically allocate
// an array of that size. The program then allows the user to enter the number of
// books each student has seen.  It then sorts the scores and calculate the average.
//******************************************************************

// Program headers
#include <iostream>
#include <iomanip>
#include <algorithm>

using namespace std;

void getData(int*, int);
void sortData(int*, int);
void displayData(int*, int);
void averageData(int*, int);

int main()
{
    int size;
    
    cout << "How many students did you survey? ";
    cin >> size;
    
    while (size < 0)
    {
        cout << "Please enter a number greater than zero: ";
        cin >> size;
    }
    
    int *booksRead = new int [size];
    getData(booksRead,size);
    
    
    sortData(booksRead,size);
    
    displayData(booksRead,size);

    averageData(booksRead, size);
    
    
    delete[] booksRead;
    
    return 0;
}



void getData(int *booksRead, int A)
{

    for( int i = 0; i < A; i++ )
    {
        cout << "Enter the number of books read by student " << i+1 << ": ";
        cin >> *booksRead;
        
        booksRead++;
    }
    cout << endl;
}



void sortData(int *booksRead, int size)
{
    sort(booksRead, booksRead+size);
}


void displayData(int *booksRead,int size)
{
    cout << "Number of books Read" << endl << "------------------------" << endl;
    for (int loop = 0; loop < size; loop++)
    {
        cout << *(booksRead+loop) <<endl;
    }
    cout << "---------" << endl;
}


void averageData(int* booksRead, int size)
{
    int sum = 0;
    float avg = 0;
    
    for (int loop = 0; loop < size; loop++)
    {
        sum += *(booksRead+loop);
    }
    
    avg = sum*1.00/size;
    
    cout << "The Average is: " << fixed << setprecision(2) << avg << endl;
}
