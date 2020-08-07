//******************************************************************
// File Encryption
// The encryption program reads the contents of a file, modifies
// each character in the input file into a code. The program then
// writes the coded characters out to a second file.
//******************************************************************

// Program headers
#include <iostream>
#include <fstream>
#include <cstdlib>

using namespace std;

int main()
{
    
    char fileName[50];
    char destinationName[50];
    ifstream file;
    ofstream outputFile;
    
    cout << "Enter the file name followed by '.txt': ";
    cin.getline (fileName,50);
    
    cout << "Enter the destination followed by '.txt': ";
    cin.getline (destinationName,50);
    
    file.open(fileName);
    outputFile.open(destinationName);
    
    if(!file.is_open())
    {
        cout << "The file does not exist";
        exit(EXIT_FAILURE);
    }
    

    
    char ch;
    while (file.good())
    {
        
        ch = file.get();
        char encrypt =char(int(ch)+7);
        outputFile << encrypt;
    }

    file.close();
    outputFile.close();
    
    cout << "Encription completed.";
    return 0;
}
