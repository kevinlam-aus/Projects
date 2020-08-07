//******************************************************************
// File Decryption
//
// The decryption program reads the contents of a file, decodes
// each character in the input file. The program then writes the
// decoded characters out to a second file.
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
    
    cout << "Enter the file name followed by '.txt' to decode: ";
    cin.getline (fileName,50);
    
    cout << "Enter the decoded destination followed by '.txt': ";
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
        char decrypt =char(int(ch)-7);
        outputFile << decrypt;
        cout << decrypt << ch << endl;
    }
    
    cout << "Decryption completed.";
    
    file.close();
    outputFile.close();
    
    return 0;
}
