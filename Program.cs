using FiscalTransmuter;
using Newtonsoft.Json;

var arrangement = await Interfacing.LoadArrangement();

var rawFiles = Directory.GetFiles(arrangement.dataDirectory);
var parsedLines = Interfacing.ReadCsvs(rawFiles);

var categories = parsedLines.GroupBy(line => line.Category)
            .Select(group => new
            {
                Category = group.Key,
                Count = group.Count()
            })
            .OrderByDescending(o => o.Count)
            .ToArray();

var jsonCount = JsonConvert.SerializeObject(categories);

var categoryPath = Path.Combine(arrangement.outputDirectory, $"categories-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.json");
File.WriteAllText(categoryPath, jsonCount);

parsedLines = parsedLines.Where(l => l.Category != Transmorgrifying.TRANSFER).ToArray();
CsvWriter.WriteToCsv(arrangement.outputDirectory, parsedLines);
;