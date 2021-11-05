# multiple-choice-test-system

### Built with Angular & ASP .NET Core & MS-SQL

## Installing / Getting started

1. For angular you need to add node modules. Run this command in your terminal.

```
npm install --save-dev @angular-devkit/build-angular
```

2. For running the API, u have to add an user secret file or update ur appsettings.

- For updating ur appsettings, u have to remove user secret reference from MCTS.API.csproj:

```
{
  "ConnectionStrings": {
    "ConStr": "YOUR_CONNECTION_STRING",
    "DbType": "YOUR_DB_TYPE"
  },
  "AppSettings": {
    "SecretKey": "YOUR_SECRET_KEY"
  }
}
```

4. Creation of database:

    - Open package manager console in Visual Studio.
    - Select 'MCTS.DB' as default project in package manager console.
    - And then run this command: ``` update-database ```

