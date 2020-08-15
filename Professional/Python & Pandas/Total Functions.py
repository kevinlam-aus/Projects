import pandas as pd

filename = input("Input File: ")

rEmployees = '/Users/'+filename+'/Desktop/Visualization/Raw Data/Employees.csv'
rEmails = '/Users/'+filename+'/Desktop/Visualization/Raw Data/Emails.csv'
rmeetings = '/Users/'+filename+'/Desktop/Visualization/Raw Data/meetings.csv'
rRequests = '/Users/'+filename+'/Desktop/Visualization/Raw Data/Requests.csv'

wEmployees = '/Users/'+filename+'/Desktop/Visualization/Edited Data/employees.csv'
wCME ='/Users/'+filename+'/Desktop/Visualization/Edited Data/meetings_Emails.csv'
wRMC ='/Users/'+filename+'/Desktop/Visualization/Edited Data/Requests_Emails.csv'


employees = pd.read_csv (rEmployees,na_filter=False)
emails = pd.read_csv (rEmails)
meetings = pd.read_csv (rmeetings)
requests = pd.read_csv (rRequests)

def getDepartments(employeesDF):
    department =[]
    for job in df["job"]:
        if job == 'doctor' or job == 'nurse' :
            department.append("Family Care")

        elif job == 'Chemist' or job == 'pharmacist' or job == 'lab technician':
            department.append("Pharmacy")

    
        elif job == "bagger" or job == 'clerk' or job == 'cashier:
            department.append("Checkout")

        else:
            department.append("ERROR")
        
    employeesDF['department'] = department
    print("  -created list of departments per line")

    return employeesDF

def getColors(employeesDF):
        
    # Add yellow or Red
    yellowRed = []
    for yR in df["yellowRed"]:
        if yR == "":
            yellowRed.append('')
        elif int(yR) > 4.5:
            yellowRed.append('Yellow')
        elif int(yR) < 4.5:
            yellowRed.append('Red')
        else:
            yellowRed.append('ERROR')

    df["yR.string"] = yellowRed
    print("  -Created list of yellow and red")

    ########################################################################################################

    # Add blue or orange
    blueOrange = []
    for BR in df["blueOrange"]:
        if LI == "":
            blueOrange.append('')
        elif int(BR) > 4.5:
            blueOrange.append('blue')
        elif int(BR) < 4.5:
            blueOrange.append('Orange')
        else:
            blueOrange.append('ERROR')

    df["BR.string"] = blueOrange
    print("  -Created list of blue and orange")

    ########################################################################################################

    # Add Green or purple
    greenPurple = []
    for GP in df["greenPurple"]:
        if GP == "":
            greenPurple.append('')
        elif int(GP) > 4.5:
            greenPurple.append('Green')
        elif int(GP) < 4.5:
            greenPurple.append('Purple')
        else:
            greenPurple.append('ERROR')

    df["GP.string"] = greenPurple
    print("  -Created list of green and purple")
    return employeesDF

def prepEmployees():
    employeesDF = pd.DataFrame(employees)
    getDepartments(employeesDF)
    getPersonalitites(employeesDF)
    employeesDF = employeesDF.rename(columns={'employeeId': 'Id'})
    employeesDF = employeesDF.rename(columns={'Name': 'label'})
    employeesDF = employeesDF.drop(columns={'_id'})
    print("  -Edited Column Names")

    ########################################################################################################

    employeesDF.to_csv(wEmployees,index=False)
    print("  -Wrote to file")

def Combine_Meetings_Emails():
    result = pd.merge(meetings, emails, how='left', left_on='_id', right_on='meetingId')
    print(" -Successfully Merged")

    result = result.rename(columns={'_id': 'Id'})
    result = result.rename(columns={'senderId': 'Source'})
    result = result.rename(columns={'recieverId': 'Target'})
    result = result.rename(columns={'emailcount': 'Weight'})
    print(" -Renamed Columns")

    result.to_csv(wCME,index=False)
    print(" -Wrote to file")

def prepRequests():
    
    result = pd.merge(requests, emails, how='left', left_on='_id', right_on='meetingId')
    print(" -Successfully Merged")

    result = result.drop(columns={'_id'})
    result = result.rename(columns={'employeeID': 'Source'})
    result = result.rename(columns={'attendeeID': 'Target'})
    print(" -Renamed Columns")

    result.to_csv(wRMC,index=False)
    print(" -Wrote to file")

  
def main():

    print("Available functions at this time:")
    print("     1. View user interaction through meetings and emails with number of emails exchanged as line thickness")
    print("         Required Columns:")
    print("             meetings: _id, senderId, recieverId")
    print("             Emails: MeetingId, emailscount")

    print("     2. View user interaction through requests")
    print("         Required Columns:")
    print("             meetings: _id, employeeID, attendeeID")
    print("             Emails: MeetingId,emailscount")

    print("All functions require employees with the following columns: \n\
        employeeId, name, job, \n\
        yellowRed,blueOrange, greenPurple, \n")

    selection = int(input("Select a number:"))
    while selection < 1 and selection > 2:
        print('Invalid Selection!')
        selection = input("Select a valid number\
        \n    1. View user interaction through meetings and emails with email as line thickness\
        \n    2. View user interaction through requests\
        \nSelection: ")

    if selection == 1:
        print("\n\n\nPreparing Employees...")
        prepEmployees()
        print("Employees prepared")

        print("\n\n\nCombining meeting and email...")
        Combine_meetings_Emails()
        print("\n Meeting and Chat combined")
    
    elif selection == 2:
        print("\n\n\nPreparing Employees...")
        prepEmployees()
        print("Employees prepared")

        print("\n\n\nCombining meeting and email...")
        prepRequests()
        print("\n Requests and Chat combined")



main()