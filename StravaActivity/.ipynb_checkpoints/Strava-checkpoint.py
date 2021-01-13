#Idea - pull strava activity to CSV as part of a ETL
#https://medium.com/analytics-vidhya/accessing-user-data-via-the-strava-api-using-stravalib-d5bee7fdde17

from stravalib.client import Client
import pickle

client = Client()
MY_STRAVA_CLIENT_ID, MY_STRAVA_CLIENT_SECRET = open('client.secret').read().strip().split(',')

print ('Client ID and secret read from file'.format(MY_STRAVA_CLIENT_ID) )
print(MY_STRAVA_CLIENT_ID, MY_STRAVA_CLIENT_SECRET)

#Create URL (paste into web browser to approve access) Only needs to be done once per user
#url = client.authorization_url(client_id=MY_STRAVA_CLIENT_ID,
#redirect_uri='http://127.0.0.1:5000/authorization',
#scope=['read_all','profile:read_all','activity:read_all'])
#print(url)

#Code is from returned url
CODE = '1c5737ef83a37b9c770d61de061d18e83e3c7940'

access_token = client.exchange_code_for_token(client_id=MY_STRAVA_CLIENT_ID,
client_secret=MY_STRAVA_CLIENT_SECRET, code=CODE)
with open('../access_token.pickle', 'wb') as f:
    pickle.dump(access_token, f)

with open('../access_token.pickle', 'rb') as f:
    access_token = pickle.load(f)
print('Latest access token read from file:', access_token)
