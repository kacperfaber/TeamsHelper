# TeamsHelper
C# WebService to synchronize Teams calendar with Google calendar.
<br>
It supports customization of reminders and colors.
<br>
We can customize what to do with canceled event 
* Delete reminders
* Change colors
* Delete event from google calendar.
<br>
It's archived right now.

## Installation 

Clone the repo
```shell
# clone the repo
git clone https://www.github.com/kacperfaber/TeamsHelper && cd TeamsHelper

# Change PWD to 'TeamsHelper.WebApp' subproject.
cd TeamsHelper.WebApp
```

Run locally
```shell
dotnet restore
dotnet run
```

## Configuration 

### Google
Default configuration file is GoogleConfiguration.json.
File must be in a working directory.

```json5
"GoogleConfiguration": {
    "DescriptionAfterCancelled": "ChangeDescription | AppendDescription | KeepDescription",
    "DeleteCanceled": false,
    "Colors": {
      "Active": "9", // google colors
      "Canceled": "8"
    },
    "Reminders": [
      {
        "MinutesBefore": 2
      }
    ],
    "CanceledReminders": []
  }
```

### Service
Default configuration file is ServiceConfiguration.json.
File must be in a working directory.
```json5
{
  "ServiceConfiguration": {
    "SleepMinutes": 180,
    "WorkOnNight": false
  }
}
```

### OAuth
Default configuration file is OAuthConfiguration.json.
File must be in a working directory.

```json5
{
  "OAuth": {
    "Configuration": {
      "Google": {
        "ClientId": "",
        "ClientSecret": "",
        "RedirectUrl": "",
        "Scopes": "openid profile email https://www.googleapis.com/auth/calendar%20https://www.googleapis.com/auth/calendar.readonly%20https://www.googleapis.com/auth/calendar.events",
        "TokenEndpoint": "https://oauth2.googleapis.com/token",
        "CodeVerifier": "",
        "CodeChallenge": "",
        "CodeChallengeMethod": "S256",
        "IdentityUrl": "https://www.googleapis.com/oauth2/v2/userinfo",
        "IdentityMethod": "GET",
        "IdentityModelKeys": {
          "Name": "name",
          "Id": "id",
          "Email": "email"
        }
      },

      "Microsoft": "The same at $.OAuth.Configuration.Google"
    }
  }
}
```

## Author

Kacper Faber
