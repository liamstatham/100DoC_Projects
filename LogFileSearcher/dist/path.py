import os
from pathlib import Path


#Test program for os file path
#Get parent path of directory
d = Path().resolve().parent




#Open file
exit = 0
while exit == 0:
    fname = input('Enter file name: ')
    if len(fname) < 1: fname = 'u_ex210102.log'
    path = os.path.join(d, fname)
    try:
        print(path)
        file = open(path)
        print('Adding logs to db...')
        exit = 1
    except:
        print('File with that name does not exist in this directory.')
        print('Please open the program and try again.')
        print(path)
