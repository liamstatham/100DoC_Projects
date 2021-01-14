import pandas as pd
#Open CSV file
df = pd.read_csv('all_data_1.csv')
#User first 5 columns in dataframe [id, name, distance, moving_time, elapsed_time]
dfpart = df.iloc[:,[0,1,2,3,4]]

#convert distance from meters to km
dfpart['distance'] = dfpart['distance'].div(1000).round(2)

#convert moving_time from seconds to minutes (working, but not the seconds part, maybe use import time?)
dfpart['moving_time'] = dfpart['moving_time'].div(60).round(2)
#print(type(dfpart['moving_time']))
print(dfpart)
#df_csv.to_csv('all.csv', index=False)
