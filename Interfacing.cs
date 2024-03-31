using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace FiscalTransmuter;

public class TransmutationArrangement
{
    public string? dataDirectory { get; set; }
    public string? outputDirectory { get; set; }
}

public class HomoginizedLine
{
    public string? YearMonth { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public double Amount { get; set; }
    public string? Source { get; set; }
}


public class UsaaLine 
{
    public string? Date { get; set; }
    public string? Description { get; set; }
    public string? OriginalDescription { get; set; }
    public string? Category { get; set; }
    public string? Amount { get; set; }
    public string? Status { get; set; }
}

public class AspirationLine 
{
    public string? TransactionDate { get; set; }
    public string? Description { get; set; }
    public string? Amount { get; set; }
    public string? PendingPosted { get; set; }
}

public static class Interfacing
{
    public async static Task<TransmutationArrangement> LoadArrangement()
    {
        string fileName = "transmutationTuning.json";
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        if (File.Exists(filePath) == true)
        {
            Console.WriteLine($"File '{fileName}' already exists at '{filePath}'.");
            var arrangementJson = await File.ReadAllTextAsync(filePath);
            var result = JsonConvert.DeserializeObject<TransmutationArrangement>(arrangementJson);
            if(result == null)
            {
                throw new Exception("Deserialization of the arrangement file resulted in a null object.");
            }
            else
            {
                return result;
            }
        }
        else
        {
            var result = new TransmutationArrangement()
            {

            };
            var arrangementJson = JsonConvert.SerializeObject(result);
            try
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine(arrangementJson); // Writing an empty JSON object
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
            return result;
        }
        
    }

    public static HomoginizedLine[] ReadCsvs(string[] fullFilePaths)
    {
        var result = Array.Empty<HomoginizedLine>();
        foreach (var fullFilePath in fullFilePaths)
        {
            using (var parser = new TextFieldParser(fullFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var headers = Array.Empty<string>();
                var lines = Array.Empty<UsaaLine>();

                var fields = parser.ReadFields();
                foreach (string field in fields)
                {
                    headers = headers.Concat(new[] { field }).ToArray();
                }

                if (headers.Length == 6 && headers.Contains("Original Description") == true)
                {
                    var usaaResult = ReadUsaaCsv("", fullFilePath);
                    result = result.Concat(usaaResult).ToArray();
                }
                else if (headers.Length == 4 && headers.Contains("Pending/posted") == true)
                {
                    var aspirationResult = ReadAspirationCsv(fullFilePath);
                    result = result.Concat(aspirationResult).ToArray();
                }
            }
        }
        return result;
    }

    public static HomoginizedLine[] ReadUsaaCsv(string dataDirectory, string fileName)
    {
        string filePath = Path.Combine(dataDirectory, fileName);
        var result = Array.Empty<HomoginizedLine>();
        using (var parser = new TextFieldParser(filePath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            var first = true;
            var headers = Array.Empty<string>();
            var lines = Array.Empty<UsaaLine>();
            while (parser.EndOfData == false)
            {
                var fields = parser.ReadFields();

                if (first == true)
                {
                    foreach (string field in fields)
                    {
                        headers = headers.Concat(new[] { field }).ToArray();
                    }
                    first = false;
                }
                else
                {
                    if (fields != null)
                    {
                        var usaaLine = new UsaaLine();
                        var i = 0;
                        foreach (string field in fields)
                        {
                            var thisHeader = headers[i];
                            switch (thisHeader)
                            {
                                case nameof(UsaaLine.Date):
                                    usaaLine.Date = field;
                                    break;
                                case nameof(UsaaLine.Description):
                                    usaaLine.Description = field;
                                    break;
                                case nameof(UsaaLine.OriginalDescription):
                                    usaaLine.OriginalDescription = field;
                                    break;
                                case nameof(UsaaLine.Category):
                                    usaaLine.Category = field;
                                    break;
                                case nameof(UsaaLine.Amount):
                                    usaaLine.Amount = field;
                                    break;
                                case nameof(UsaaLine.Status):
                                    usaaLine.Status = field;
                                    break;
                                default:
                                    // Handle unexpected headers if needed
                                    break;
                            }
                            i++;
                        }
                        lines = lines.Concat(new[] { usaaLine }).ToArray();
                    }
                }

                
            }

            result = lines.Select(l =>
            {
                double.TryParse(l.Amount, out var amount);
                var yearMonth = "";
                var transactionDate = (DateTime?)null;
                if(DateTime.TryParse(l.Date, out var date) == true)
                {
                    yearMonth = $"{date:yy-MM}";
                    transactionDate = date;
                }

                

                var homline = new HomoginizedLine()
                {
                    Amount = amount,
                    Category = l.Category,
                    Description = l.Description,
                    YearMonth = yearMonth,
                    TransactionDate = transactionDate,
                    Source = "USAA"
                };

                homline = Transmorgrifying.Transmogrify(homline);

                return homline;
            }).ToArray();
        }
        return result;
    }

    public static HomoginizedLine[] ReadAspirationCsv(string filePathName)
    {
        var result = Array.Empty<HomoginizedLine>();
        using (var parser = new TextFieldParser(filePathName))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            var first = true;
            var headers = Array.Empty<string>();
            var lines = Array.Empty<AspirationLine>();
            while (parser.EndOfData == false)
            {
                var fields = parser.ReadFields();

                if (first == true)
                {
                    foreach (string field in fields)
                    {
                        headers = headers.Concat(new[] { field }).ToArray();
                    }
                    first = false;
                }
                else
                {
                    if (fields != null)
                    {
                        var aspirationLine = new AspirationLine();
                        var i = 0;
                        foreach (string field in fields)
                        {
                            var thisHeader = headers[i];
                            switch (thisHeader)
                            {
                                case "Transaction date":
                                    aspirationLine.TransactionDate = field;
                                    break;
                                case nameof(AspirationLine.Description):
                                    aspirationLine.Description = field;
                                    break;
                                case nameof(AspirationLine.Amount):
                                    aspirationLine.Amount = field;
                                    break;
                                case "Pending/posted":
                                    aspirationLine.PendingPosted = field;
                                    break;
                                default:
                                    // Handle unexpected headers if needed
                                    break;
                            }
                            i++;
                        }
                        lines = lines.Concat(new[] { aspirationLine }).ToArray();
                    }
                }


            }

            result = lines.Select(l =>
            {
                double.TryParse(l.Amount, out var amount);
                var yearMonth = "";
                var transactionDate = (DateTime?)null;
                try
                {
                    var exactDate = DateTime.ParseExact(l.TransactionDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    yearMonth = $"{exactDate:yy-MM}";
                    transactionDate = exactDate;
                }
                catch
                {
                    if (DateTime.TryParse(l.TransactionDate, out var date) == true)
                    {
                        yearMonth = $"{date:yy-MM}";
                        transactionDate = date;
                    }
                }
                

                var homLine = new HomoginizedLine()
                {
                    Amount = amount,
                    Description = l.Description,
                    YearMonth = yearMonth,
                    TransactionDate = transactionDate,
                    Source = "Aspiration"
                };

                homLine = Transmorgrifying.Transmogrify(homLine);

                return homLine;
            }).ToArray();
        }
        return result;
    }
}


public static class CsvWriter
{
    public static void WriteToCsv(string dataDirectory, IEnumerable<HomoginizedLine> lines)
    {
        var fileName = $"Output-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.csv";
        var filePath = Path.Combine(dataDirectory, fileName);
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("YearMonth,Description,Category,Amount,Source");

            foreach (var line in lines)
            {
                var monthName = $"{line.TransactionDate:MMM}";
                string csvLine = $"=\"{EscapeCsvField(line.YearMonth)} ({monthName})\",{EscapeCsvField(line.Description)},{EscapeCsvField(line.Category)},{line.Amount},{line.Source}";

                writer.WriteLine(csvLine);
            }
        }
    }

    private static string EscapeCsvField(string field)
    {
        // If field contains comma, double-quote, or newline, enclose it in double quotes and double any existing double quotes
        if (field != null && (field.Contains(",") || field.Contains("\"") || field.Contains("\n")))
        {
            return "\"" + field.Replace("\"", "\"\"") + "\"";
        }
        return field;
    }
}