import pandas as pd
from pandas.io.json import json_normalize
import seaborn as sns
import matplotlib.pyplot as plt
import numpy as np
from datetime import datetime
from pathlib import Path
import os

#Open CSV file
dir = Path().resolve()
folder = 'CSV files'
file = 'all_data_1.csv'
path = os.path.join(dir, folder, file)
#print(path)
df = pd.read_csv(path)

#print(df.columns)
#User first 5 columns in dataframe [id, name, distance, moving_time, elapsed_time]
#dfpart = df.iloc[:,[0,1,2,3,4]]

#convert distance from meters to km
#dfpart['distance'] = dfpart['distance'].div(1000).round(2)

#convert moving_time from seconds to minutes (working, but not the seconds part, maybe use import time?)
#dfpart['moving_time'] = dfpart['moving_time'].div(60).round(2)
#print(type(dfpart['moving_time']))
#print(dfpart)
#df_csv.to_csv('all.csv', index=False)

#Create new dataframe with only columns I care about
cols = ['name', 'upload_id', 'type', 'distance', 'moving_time',
         'average_speed', 'max_speed','total_elevation_gain',
         'start_date_local'
       ]
activities = df[cols]
#print(df[cols])
#Break date into start time and date
activities['start_date_local'] = pd.to_datetime(activities['start_date_local'])
activities['start_time'] = activities['start_date_local'].dt.time
activities['start_date_local'] = activities['start_date_local'].dt.date
activities.head(5)
#print(activities)
