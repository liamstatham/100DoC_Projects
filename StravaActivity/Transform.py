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

#User first 5 columns in dataframe [id, name, distance, moving_time, elapsed_time]
cols = ['distance','moving_time','type']
#print(df[cols])
run = df['type'] = 'Run'
print(run)




#convert distance from meters to km
#dfpart[2] = dfpart[2].div(1000).round(2)

