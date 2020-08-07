//******************************************************************
// Word Separator

// The program accepts an sentence with all the words running together
// while the first character of each word is an uppercase letter.
// The program convert the sentences to a string with the words separated by
// spaces and only the first word starts with an uppercase letter.
//******************************************************************

// Program headers
#include <iostream>
#include <string>
#include <cstring>
#include <cctype>

using namespace std;

int main()
{
    string sentence;
    
    cout << "Enter a sentence with no spaces where the beginning of each word is uppercase: ";
    cin >> sentence;
    
    cout << "Original sentence: " << sentence << endl;
        
    
    int length;
    length = sentence.size();
    char temp, nSentence[length];
    int nloop = 1;
    nSentence[0] = sentence[0];
    
    for (int loop = 1; loop < length; loop++)
    {
        temp = sentence[loop];

        if (isupper(temp))
        {
            nSentence[nloop] = ' ';
            ++nloop;
            nSentence[nloop] = tolower(sentence[loop]);
        }
        else
        {
            nSentence[nloop] = sentence[loop];
            
        }
        ++nloop;
    }
    
    
        cout << "New sentence: " << nSentence << endl;

    
    
    
    
    return 0;
}
