using FiscalTransmuter;

var arrangement = await Interfacing.LoadArrangement();

var parsedLines = Interfacing.ReadUsaaCsv(arrangement.dataDirectory, "bk_download(1).csv");
CsvWriter.WriteToCsv(arrangement.outputDirectory, parsedLines);
;