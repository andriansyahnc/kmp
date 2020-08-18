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

