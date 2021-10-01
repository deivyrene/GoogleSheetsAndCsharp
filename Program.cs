using System;
using System.IO;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;

namespace GoogleSheetsAndCsharp
{
  class Program
  {
    static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static readonly string ApplicationName = "Aplication Name";
    static readonly string SpreadsheetId = "spreadsheet ID";
    static readonly string sheet = "spreadsheet name";
    static SheetsService service;

    static void Main(string[] args)
    {
      GoogleCredential credential;
      using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
      {
        credential = GoogleCredential.FromStream(stream)
            .CreateScoped(Scopes);
      }

      // Create Google Sheets API service.
      service = new SheetsService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = ApplicationName,
      });

      ReadEntries();
    }

    static void ReadEntries()
    {
      var range = $"{sheet}!A:N";
      SpreadsheetsResource.ValuesResource.GetRequest request =
              service.Spreadsheets.Values.Get(SpreadsheetId, range);

      var response = request.Execute();
      var values = response.Values;
      if (values != null && values.Count > 0)
      {
        foreach (var row in values)
        {
          // Print columns A to N, which correspond to indices 0 and 4.
          Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
        }
      }
      else
      {
        Console.WriteLine("No data found.");
      }
    }
  }
}
