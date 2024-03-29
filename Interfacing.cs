using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace FiscalTransmuter;

public class TransmutationArrangement
{
    public string? dataDirectory { get; set; }
}

public class HomoginizedLine
{
    public string? YearMonth { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public double Amount { get; set; }
    
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

    public static readonly Dictionary<string, string> _usaaHeaderMaps = new Dictionary<string, string>()
    {
        { "Description", nameof(HomoginizedLine.Description) },
        { "Amount", nameof(HomoginizedLine.Amount) },
        { "Category", nameof(HomoginizedLine.Category) }
    };

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
                if(DateTime.TryParse(l.Date, out var date) == true)
                {
                    yearMonth = $"{date:yy-MM}";
                }

                return new HomoginizedLine()
                {
                    Amount = amount,
                    Category = l.Category,
                    Description = l.Description,
                    YearMonth = yearMonth
                };
            }).ToArray();
        }
        return result;
    }

    public async static Task<HomoginizedLine[]> ReadCsv(string? dataDirectory, string fileName)
    {
        string filePath = Path.Combine(dataDirectory, fileName);
        var result = Array.Empty<HomoginizedLine>();
        try
        {
            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var first = true;
                var headers = Array.Empty<string>();
                while (parser.EndOfData == false)
                {
                    var fields = parser.ReadFields();
                    if(fields == null)
                    {
                        throw new Exception("null fields");
                    }

                    if(first == true)
                    {
                        foreach (string field in fields)
                        {
                            headers = headers.Concat(new[] { field }).ToArray();   
                        }
                    }

                    if (fields != null)
                    {
                        var homLine = new HomoginizedLine();
                        var i = 0;
                        foreach (string field in fields)
                        {
                            var thisHeader = headers[i];
                            if (double.TryParse(field, out var amount) == true && thisHeader.ToLower().Contains("amount"))
                            {
                                homLine.Amount = amount;
                            }
                        }
                        Console.WriteLine();
                    }

                    first = false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        return await Task.FromResult(result);
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
            writer.WriteLine("YearMonth,Description,Category,Amount");

            foreach (var line in lines)
            {
                string csvLine = $"{EscapeCsvField(line.YearMonth)},{EscapeCsvField(line.Description)},{EscapeCsvField(line.Category)},{line.Amount}";

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