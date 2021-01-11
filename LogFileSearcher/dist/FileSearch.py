import sqlite3
from datetime import datetime
import csv
import sys
from pathlib import Path
import os

#Create sqlite database
conn = sqlite3.connect('logdb.sqlite', isolation_level='DEFERRED')
cur = conn.cursor()
cur.execute('''PRAGMA synchronous = OFF''')
cur.execute('''PRAGMA journal_mode = OFF''')

cur.execute('''DROP TABLE IF EXISTS Logs''')
#Create logs table
cur.execute('''
CREATE TABLE if not exists Logs (
    LogID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
    Created DATETIME,
    Method TEXT,
    UriStem TEXT,
    UriQuery TEXT,
    Port INTEGER,
    IP TEXT,
    UserAgent TEXT,
    URL TEXT,
    TimeTaken INTEGER
); ''')

#Get parent path of directory
d = Path().resolve().parent

#Open file
exit = 0
while exit == 0:
    fname = input('Enter file name: ')
    if len(fname) < 1: fname = 'u_ex210102.log'
    #Use os path join to add path of parent directory and filename
    path = os.path.join(d, fname)
    try:
        file = open(path)
        print('Adding logs to db...')
        exit = 1
    except:
        print('File with that name does not exist in this directory.')
        print('Please open the program and try again.')
        print()
    #    sys.exit(0)

#Variables for new and current records in the database
newrecords = 0
currentrecords = 0

for lines in file:
#splits file into lines beginging with 2021
    if not lines.startswith('2021'):continue
    line = lines.split()
#need to convert line[0] and line[1] from string to datetime
    bigdate = line[0]
    time = line[1]
    fulldate = (bigdate + ' ' + time)
    dt = datetime.fromisoformat(fulldate)
#Above converts part 0 and 1 from log file line to a full date. using datetime
    port = int(line[6])
    timetaken = int(line[16])
    cur.execute(
    '''INSERT INTO Logs (Created, Method, UriStem, UriQuery, Port, IP, UserAgent, URL, TimeTaken)
    VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)''',
    (dt, line[3], line[4], line[5], port, line[8], line[9], line[10], timetaken))
    newrecords = newrecords + 1
    conn.commit()

print('Number of logs added to database: ',newrecords)

#Function to return database row of relevant logid
def returnvalues(logid):
    cur.execute('''SELECT * FROM Logs WHERE LogID = ?''',(logid,))
    print('This is row: ', logid)
    print(cur.fetchone())

#loop through rows in table
cur.execute('''SELECT COUNT(LogID) FROM Logs''')
rows = cur.fetchone()
rowsint = rows[0]
logid = 1
exit = 0
while logid < rowsint:
    if exit == 1:
        break
    else:
        response = input('Next row? y or n: ')
        if response == 'y':
            returnvalues(logid)
            logid = logid + 1
        elif response == 'n':
            exit = 1
        else:
            print('Incorrect entry, please use Y or N.')
            print()
else:
    print('No more rows.')

#Search through database to filter results to CSV
exit = 0
while exit == 0:
    searchURL = input('Search in URL (turnaroundID/ContainerMasterId etc)? y or n: ')
    if searchURL == 'y':
        term = input('Type search term between wildcards %... eg: %test%: ')
        cur.execute('''SELECT count(LogID) FROM Logs WHERE URL LIKE ?''',(term,))
        scount = cur.fetchone()
        print('There are',scount[0],'results.')
        resultcsv = input('Print results to CSV? y or n: ')
        if resultcsv == 'y':
            print('Adding', scount[0], 'rows to CSV.' )
            csvWriter = csv.writer(open("logdb_rows.csv", "w", newline = ''))
            lrows = cur.execute('''SELECT * FROM Logs WHERE URL LIKE ?''',(term,))
            csvWriter.writerow(['LogID', 'Created','Method' ,'UriStem','UriQuery' ,'Port' ,'IP' ,'UserAgent' ,'URL' ,'TimeTaken (ms)'] )
            csvWriter.writerows(lrows)
            print('Successfully created logdb_rows.csv.')
            cur.close()
            sys.exit(0)
        elif resultcsv == 'n':
            exit = 1
        else:
            print('Incorrect entry, please use Y or N.')
            print()
    elif searchURL == 'n':
        exit = 1
    else:
        print('Incorrect entry, please use Y or N.')
        print()

#Below prints rows to CSV file
exit = 0
while exit == 0:
    printrows = input('Print full database to CSV? y or n: ')
    if printrows == 'y':
            print('Adding', rows[0], 'rows to CSV.' )
            csvWriter = csv.writer(open("logdb_rows.csv", "w", newline = ''))
            lrows = cur.execute('''SELECT * FROM Logs ORDER BY LogID''')
            csvWriter.writerow(['LogID', 'Created','Method' ,'UriStem','UriQuery' ,'Port' ,'IP' ,'UserAgent' ,'URL' ,'TimeTaken (ms)'] )
            csvWriter.writerows(lrows)
            print('Successfully created logdb_rows.csv.')
            cur.close()
            exit = 1
    elif printrows == 'n':
    #close database connection
        print('Closing program.')
        cur.close()
        sys.exit(0)
    else:
        print('Incorrect entry, please use Y or N.')
        print()
