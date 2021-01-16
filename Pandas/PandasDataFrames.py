import numpy as np
import pandas as pd

#Rows and column names in normal python lists 
rows = ['X', 'Y', 'Z']
cols = ['A', 'B', 'C', 'D', 'E']

#Use numpy to create random data for the dataframe
data = np.round(np.random.randn(3,5),2)

#wrap everything in a data frame
df = pd.DataFrame(data, rows, cols)
#this prints the dataframe
#print(df)
#Could have created everything inside the dataframe, doesn't need to be python lists
#You can call specific series (only columns) from a dataframe

#print(df['A'])
#You can oass in a list of columns direct or through a variable like:
#columns = ['A','B','E']
#print(df[columns])

#You can also return a column and a row, just return the cell required
#print(df['A']['X'])

#You can add new columns to dataframe
df['A+B'] = df['A'] + df['B']
#print(df)
#to delete that new column
#df.drop('A+B', axis=1)
#print(df)

#printing rows
#rows have a loc atribute, can be done by label or by numberical index using iloc
print(df.loc['X'])
print(df.iloc[0])