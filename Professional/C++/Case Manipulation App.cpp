//******************************************************************
// Case Manipulation
//
// This program with three functions:  upper, lower, and flip.
// Each function accepts a C-string as an argument.
// The upper function steps through all the characters in the string, converting each to uppercase.
// The lower function, steps through all the characters in the string converting, each to lowercase.
// The flip steps through the string, testing each character to determine whether it is upper or lowercase.
// (If upper, it should convert to lower. If lower, it should convert to upper.)
//******************************************************************

// Program headers
#include <iostream>
#include <string>
#include <cstring>
#include <cctype>

using namespace std;

void upper(char *);
void lower(char *);
void flip(char *);

int main()
{
    int MAXLENGTH = 50;
    char string[MAXLENGTH];
    
    cout << "Enter a string: ";
    cin.getline(string, MAXLENGTH);
    
    cout << "Original String: " << string << endl;
    
    
    upper(string);
    lower(string);
    flip(string);
    
    return 0;
}

void upper(char string[])
{
    char string_upper[50];
    
    for (int loop = 0; string[loop] != '\0'; loop++)
    {
        string_upper[loop] = toupper(string[loop]);
    }
    cout << "Uppercase String: " << string_upper << endl;
    
}

void lower(char string[])
{
    char string_lower[50];
    
    for (int loop = 0; string[loop] != '\0'; loop++)
    {
        string_lower[loop] = tolower(string[loop]);
    }
    cout << "Lowercase String: " << string_lower << endl;
    
}

void flip(char string[])
{
    char string_flip[50];
    
    for (int loop = 0; string[loop] != '\0'; loop++)
    {
        if (islower(string[loop]))
            string_flip[loop] = toupper(string[loop]);
        
        else
            string_flip[loop] = tolower(string[loop]);
    }
    cout << "Flipcase String: " << string_flip << endl;
    
}
