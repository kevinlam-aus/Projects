#Assigns a department to a user based on job



import pandas as pd
print("  -imported pandas as pd")

users = pd.read_csv (r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Raw Data/Employees.csv',na_filter=False)
print("  -Read file")

df = pd.DataFrame(users)

########################################################################################################

#Add department
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
    
df['department'] = department
print("  -created list of departments per line")

########################################################################################################

df = df.rename(columns={'EmployeeID': 'Id'})
df = df.rename(columns={'name': 'label'})
print("  -Edited Column Names")

########################################################################################################

df.to_csv(r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Edited Data/employees.csv',index=False)
print("  -Wrote to file")
