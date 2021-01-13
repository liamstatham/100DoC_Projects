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
page = 1
r = requests.get(url + '?access_token=' + access_token)
r = r.json()

#print(url + '?access_token=' + access_token + '&per_page=200' + '&page=' + str(page))
#Add data to the dataframe per page
while True:
    # get page of activities from Strava
    r = requests.get(url + '?access_token=' + access_token + '&per_page=200' + '&page=' + str(page))
    r = r.json()

    # if no results then exit loop
    if (not r):
        break

#this doesn't work, as it adds the last page to dataframe but wipes out previous dataviz
#need to find a way to continually add data to dataframe
#maybe append
    if page == 1:
        df = pd.json_normalize(r)
        print('Page',page,'complete.')
        page = page + 1
    else:
        if page == 2:
            df1 = pd.json_normalize(r)
            print('Page',page,'complete.')
            df.append(df1)
            print('Append to data frame complete.')
            page = page + 1
        else:
            if page == 3:
                df2 = pd.json_normalize(r)
                print('Page',page,'complete.')
                df.append(df2)
                print('Append to data frame complete.')
                page = page + 1
            else:
                if page == 4:
                    df3 = pd.json_normalize(r)
                    print('Page',page,'complete.')
                    df.append(df3)
                    print('Append to data frame complete.')
                    page = page + 1
                else:
                    if page == 5:
                        df4 = pd.json_normalize(r)
                        print('Page',page,'complete.')
                        df.append(df4)
                        print('Append to data frame complete.')
                        page = page + 1

#data fields
#df = pd.json_normalize(r)
print('Creating CSV.')
df.to_csv('all_activities_all_fields.csv')
