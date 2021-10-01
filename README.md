# GoogleSheetsAndCsharp

Repository created to provide connection to Google Sheets with csharp, using a GET from the Google Sheets library.

## Requirement

- Have installed the [dotnet](https://dotnet.microsoft.com/download) version at least 5.0.401
- Have credentials from Google Api platform:
  - Go to the Google APIs Console.
  - Create a new project.
  - Click Enable API. Search for and enable the Google Drive API and the Google Sheets API.
  - Create credentials for a Web Server to access Application Data.
  - Name the service account and grant it a Project Role of Editor.
  - Download the JSON file and paste in the root of the project as `client_secrets`.

## Configuration

- Indicate the name of the project

```c#
  static readonly string ApplicationName = "Aplication Name";
```

- Indicate the ID of the google spreadsheet spreadsheet

```c#
  static readonly string SpreadsheetId = "spreadsheet ID";
```

- Indicate the name of the spreadsheet (The name that is reflected in the bottom tab of the sheet)

```c#
  static readonly string sheet = "spreadsheet name";
```

- Indicate range of columns

```c#
  var range = $"{sheet}!A:N";
```

## Execute

Run in the terminal of your choice:

Install GoogleApisSheet

```c#
dotnet add package Google.Apis.Sheets.v4
```

From the root of the project, execute `dotnet run`, must be printed in console, the items consulted
