#Idea - pull strava activity to CSV as part of a ETL
#https://medium.com/swlh/using-python-to-connect-to-stravas-api-and-analyse-your-activities-dummies-guide-5f49727aac86
import requests
import json
# Make Strava auth API call with your
# client_code, client_secret and code
response = requests.post(
                    url = 'https://www.strava.com/oauth/token',
                    data = {
                            'client_id': 47741,
                            'client_secret': 'e37ab370f9deaa7ea6b19060b03baf213af76e13',
                            'code': '3f21121014917024c6db7ecfb1b2c4c51fd70f33',
                            'grant_type': 'authorization_code'
                            }
                )
#Save json response as a variable
strava_tokens = response.json()
# Save tokens to file
with open('strava_tokens.json', 'w') as outfile:
    json.dump(strava_tokens, outfile)
# Open JSON file and print the file contents
# to check it's worked properly
with open('strava_tokens.json') as check:
  data = json.load(check)
print(data)


#http://www.strava.com/oauth/authorize?client_id=47741&response_type=code&redirect_uri=http://localhost/exchange_token&approval_prompt=force&scope=profile:read_all,activity:read_all
#3f21121014917024c6db7ecfb1b2c4c51fd70f33
