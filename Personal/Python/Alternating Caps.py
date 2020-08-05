def main():
    count = 1
    bigLoop = 'y'
    
    while bigLoop == 'y':
        loop = 2
        sponge = ''
        print()
        print()
        print("\nWelcome to the Alternating Caps Converter\n")
        print("This type of text is great paired with the spongebob chicken meme\n")
        regular = input('Enter a string to be converted: ')
        regular = regular.lower()

        for char in regular:
                
            if char == ' ':
                case = -1
            
            else:
                if loop % 2 == 0:
                    case = 1
                else:
                    case = 9999
                loop += 1
                
            if case == 1:
                alternating += char.upper()
                count += 1

            elif case == -1:
                alternating += ' '

            else:
                alternating += char
                count += 1

        print()
        print("The converter generated the following:") 
        print(alternating)
        print()

        bigLoop = input ("would you like to convert another string? (y/n): ")

    print("I dOnT wAnT tO cOnVeRt AnYmOrE")




main()
