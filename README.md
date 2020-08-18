# README

## Installation

Copy the appsettings.json.example to appsettings.json 
```
cp KMP/appsettings.json.example KMP/appsettings.json
```
modify your `appsettings.json` configuration on this line.
```
  [...]
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "KMPMySQL": "server=localhost;port=3306;user=root;password=yourpassword;database=kmp;Convert Zero Datetime=True"
  }
  [...]
```
Restore the dependencies
```
dotnet restore
```

## API Collection

Get Todos  
```
GET https://localhost:5001/api/Todo
```

Get Today Todos
```
GET https://localhost:5001/api/Todo?Start=now
```

Get Tomorrow Todos
```
GET https://localhost:5001/api/Todo?Start=tomorrow
```

Get Current Week's Todos
```
GET https://localhost:5001/api/Todo?Start=current_week
```

Create Todo
```
POST https://localhost:5001/api/Todo
{
    "title": "Learn Something",
    "description": "Learn Somethings Best Practice",
    "percentage": 0,
    "created": "2020-08-18T13:38:02+07:00",
    "started": "2020-08-19T00:00:00",
    "expired": null
 }
```

Get specific todo
```
GET https://localhost:5001/api/Todo/<id>
```

Update Todo
```
PUT https://localhost:5001/api/Todo/<id>
{
    "id": <id>
    "title": "Learn Something",
    "description": "Learn Somethings Best Practice",
    "percentage": 0,
    "created": "2020-08-18T13:38:02+07:00",
    "started": "2020-08-19T00:00:00",
    "expired": null
 }
```

Delete Todo
```
DELETE https://localhost:5001/api/Todo/<id>
```