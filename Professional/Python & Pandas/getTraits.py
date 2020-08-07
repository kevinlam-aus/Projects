#Assigns a personality to a user based on personality score

import pandas as pd
print("  -Imported pandas as pd")

employees = pd.read_csv (r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Raw Data/Employees.csv',na_filter=False)
print("  -Read file")

df = pd.DataFrame(employees)

########################################################################################################

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

########################################################################################################

df = df.rename(columns={'employeeID': 'Id'})
df = df.rename(columns={'Name': 'label'})
df = df.drop(columns={'_id'})
print("  -Edited Column Names")

########################################################################################################

df.to_csv(r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Edited Data/employees.csv',index=False)
print("  -Wrote to file")
