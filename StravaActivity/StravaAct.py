import requests
import pandas as pd
import json
import csv
# Get the tokens from file to connect to Strava
with open('strava_tokens.json') as json_file:
    strava_tokens = json.load(json_file)
# Loop through all activities
url = "https://www.strava.com/api/v3/activities"
access_token = strava_tokens['access_token']

#loop through all activities on strava
page = 0
r = requests.get(url + '?access_token=' + access_token)
r = r.json()

#print(url + '?access_token=' + access_token + '&per_page=200' + '&page=' + str(page))
#Add data to the dataframe per page
while True:
    # get page of activities from Strava
    page = page + 1
    r = requests.get(url + '?access_token=' + access_token + '&per_page=200' + '&page=' + str(page))
    r = r.json()
    print('json request returned.')

    # if no results then exit loop
    if (not r):
        print('json request empty.')
        break
#Loop through pages and add the page of 200 json results to a dataframe
    if page == 1:
        df = pd.json_normalize(r)
        print('Data Frame created')
        print('Page',page,'complete.')
    elif page == 2:
        df1 = pd.json_normalize(r)
        print('Page',page,'complete.')
    elif page == 3:
        df2 = pd.json_normalize(r)
        print('Page',page,'complete.')
    elif page == 4:
        df3 = pd.json_normalize(r)
        print('Page',page,'complete.')
#    elif page == 5:
#        df4 = pd.json_normalize(r)
#        print('Page',page,'complete.')
#        df.append(df4)
#        print('Append to data frame complete.')

#append all data frames together, ignoring index (so row id's incrememnt normally)
print('Attempting to append to 1 df.')
adf = df.append([df1,df2,df3], ignore_index = True)
#Create CSV file for all data
print('Creating big csv')
adf.to_csv('all_data.csv')
print('complete')


#0361771416ae5767cd7e57987e51582b91fad240
