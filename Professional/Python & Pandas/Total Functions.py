print("Before beginning make sure:")
print("     1. Combine_Meetings_Emails.py, getTraits, and getDepartment.py are in this folder")
print("     2. In both functions, you have the correct input and output folders selected")
print("     3. Raw Data includes Meetings.csv, Emails.csv, and Employees.csv")

selection = input("Would you like to: \
    \n    1. Combine Meetings and Emails\
    \n    2. Append department to user\
    \n    3. Append traits to user\
    \n    4. Do all\
    \nSelect a number: ")

while int(selection) > 4 and int(selection) < 1:
    print('Invalid Selection!')
    selection = input("Select a letter between a-d to either\
    \n    1. Combine Meetings and Emails\
    \n    2. Append department to user\
    \n    3. Append traits to user\
    \n    4. Do all\
    \nSelection: ")

if selection == '1':
    print("\n\n\nCombining email and meetings...")
    import Combine_Meetings_Emails
    print("\nMeetings and Emails combined")

elif selection == '2':
    print("\n\n\nAppending department to employees...")
    import getDepartment
    print("Department appended to employee")


elif selection == '3':
    print("\n\n\nAppending traits to employee...")
    import getTraits
    print("Traits appended to employee")

else:
    print("\n\n\nCombining email and meetings...")
    import Combine_Meetings_Emails
    print("\nMeetings and Emails combined")
    print("\n\n\nAppending department to employees...")
    import getDepartment
    print("Department appended to employee")
    print("\n\n\nAppending traits to employee...")
    import getTraits
    print("Traits appended to employee")
