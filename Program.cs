using FiscalTransmuter;

var arrangement = await Interfacing.LoadArrangement();

var rawFiles = Directory.GetFiles(arrangement.dataDirectory);
var parsedLines = Interfacing.ReadCsvs(rawFiles);
CsvWriter.WriteToCsv(arrangement.outputDirectory, parsedLines);
;