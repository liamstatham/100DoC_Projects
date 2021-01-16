#https://www.freecodecamp.org/news/the-ultimate-guide-to-the-pandas-library-for-data-science-in-python/#introduction-to-pandas
import numpy as np

import pandas as pd

labels = ['a', 'b', 'c']

my_list = [10, 20, 30]

arr = np.array([10, 20, 30])

d = {'a':10, 'b':20, 'c':30}
#In a series 2 columns are generated, first is a label and 2nd is the list. You can index the labels by creating a labels list (above)
#and doing a , index=variable in the pd.Series

series = pd.Series(my_list, index=labels)

#You can reference the list using the label index (0,1,2,3, etc) or by the index added (a,,b,c etc)
#below both print the same value 20
#print(series[1])
#print(series['b'])

#You can also pass in a dictionary (key-value) to a Series, so you can already know the label(key)of a value

sdic = pd.Series(d)
print(sdic)
