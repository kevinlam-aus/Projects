# Combine Emails and meetings csv file

import pandas as pd
print(" -Imported pandas as pd")

chats = pd.read_csv (r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Raw Data/Emails.csv')
print(" -Read Chats file")

matches = pd.read_csv (r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Raw Data/Meetings.csv')
print(" -Read Matches file")

result = pd.merge(matches, chats, how='left', left_on='_id', right_on='meetingID')
print(" -Successfully Merged")

result = result.rename(columns={'_id': 'Id'})
result = result.rename(columns={'requesterId': 'Source'})
result = result.rename(columns={'accepterId': 'Target'})
result = result.rename(columns={'emailcount': 'Weight'})
print(" -Renamed Columns")

result.to_csv(r'/Users/kevinlam/Desktop/Data_Analytics/Visualization/Edited Data/Emails_Meetings.csv',index=False)
print(" -Wrote to file")
