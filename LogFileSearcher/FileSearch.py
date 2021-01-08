import sqlite3
from datetime import datetime
import csv

#Create sqlite database
conn = sqlite3.connect('logdb.sqlite', isolation_level='DEFERRED')
cur = conn.cursor()
cur.execute('''PRAGMA synchronous = OFF''')
cur.execute('''PRAGMA journal_mode = OFF''')

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


#Open file
fname = input('Enter file name: ')
if len(fname) < 1: fname = 'u_ex210102.log'
file = open(fname)
print('Adding log to db...')

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
    method = line[3]
    uristem = line[4]
    uriquery = line[5]
    port = int(line[6])
    ip = line[8]
    useragent = line[9]
    url = line[10]
    timetaken = int(line[16])
#Add new records to table if they don't already exist in the database
    cur.execute('''SELECT Created, Method, UriStem FROM Logs WHERE Created = ? AND Method = ? AND UriStem = ?''', (dt, method, uristem))
    row = cur.fetchone()
    if row is None:
        cur.execute(
        '''INSERT INTO Logs (Created, Method, UriStem, UriQuery, Port, IP, UserAgent, URL, TimeTaken)
        VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)''',
        (dt, method, uristem, uriquery, port, ip, useragent, url, timetaken))
        newrecords = newrecords + 1
    else:
        currentrecords = currentrecords + 1
    conn.commit()

print('Number of records already in the database: ',currentrecords)
print('Number of records added to database: ',newrecords)

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
        if response == 'n':
            print('Exiting program')
            exit = 1
else:
    print('No more rows.')

printrows = input('Print added rows to CSV? y or n: ')
if printrows == 'y':
        print('Adding', rows[0], 'rows to CSV.' )
        csvWriter = csv.writer(open("logdb_rows.csv", "w", newline = ''))
        lrows = cur.execute('''SELECT * FROM Logs ORDER BY LogID''')
        csvWriter.writerow(['LogID', 'Created','Method' ,'UriStem','UriQuery' ,'Port' ,'IP' ,'UserAgent' ,'URL' ,'TimeTaken (ms)'] )
        csvWriter.writerows(lrows)
        print('successfly created logdb_rows.csv.')
        cur.close()
else:

#close database connection
    cur.close()



#logfile info
#Fields: (0 date) (1 time) (2 s-ip) (3 cs-method) (4 cs-uri-stem + cs-uri-query)
#(6 s-port) (7 cs-username) (8 c-ip) (9 cs(User-Agent))
#(10 cs(Referer)) (11 sc-status) (12 sc-substatus)
#(13 sc-win32-status) (14 sc-bytes) (15 cs-bytes) (16 time-taken)
