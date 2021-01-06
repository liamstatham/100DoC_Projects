import sqlite3
from datetime import datetime
#Create sqlite database
conn = sqlite3.connect('logdb.sqlite')
cur = conn.cursor()

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

#Sql query to print top record
response = input('Print top record? y or n: ')
if response == 'y':
    cur.execute('''SELECT * FROM Logs ORDER BY Created''')
    print(cur.fetchone())
else:
    print('Program closing.')
#Query to print next record - will need to associate rows and select next id.
response = input('Next row? y')
if response == 'y':
    print(cur.fetchnextrow())

#close database connection
    cur.close()



#logfile info
#Fields: (0 date) (1 time) (2 s-ip) (3 cs-method) (4 cs-uri-stem + cs-uri-query)
#(6 s-port) (7 cs-username) (8 c-ip) (9 cs(User-Agent))
#(10 cs(Referer)) (11 sc-status) (12 sc-substatus)
#(13 sc-win32-status) (14 sc-bytes) (15 cs-bytes) (16 time-taken)
