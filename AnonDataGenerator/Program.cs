using AnonDataGenerator.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnonDataGenerator
{
    class Program
    {
        private static IConfiguration _config;
        private static DataDefinition _dataDefinition { get; set; }

        private static Dictionary<string, List<string>> _outputData { get; set; }

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder().AddJsonFile("Settings.json", false, true).Build();
            _outputData = new Dictionary<string, List<string>>();

            await ProcessDataDefinition(_dataDefinition);

            await FormatData();

            //await SaveOutput();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Data Generated");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Press any key to exit!");
            Console.Read();
        }

        static Task<bool> ProcessDataDefinition(DataDefinition dd) 
        {
            string dataFormatContent = File.ReadAllText(_config["DataFormatPath"]);

            _dataDefinition = JsonConvert.DeserializeObject<DataDefinition>(dataFormatContent);

            var count = 1;
            _dataDefinition.ColumnDefinitions.ForEach(async x => {
                try
                {

                    Console.WriteLine($"{count}) {x.ColumnName}");

                    var obj = DataFactory.GenerateDataType(x.DataType, _dataDefinition.RowCount);

                    List<string> values = new List<string>();

                    var genData = await obj.GeneratedData();
                    
                    genData.ForEach((i) =>
                    {
                        Console.WriteLine($"\t {i}");
                    });

                    values = await obj.GeneratedData();

                    _outputData.Add(x.ColumnName, values);

                    count++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });

            return Task.FromResult(true);
        }

        static Task<bool> FormatData() 
        {
            List<string> headers = _outputData.Keys.ToList();
            
            headers.ForEach(i => {
                Console.WriteLine(i);
            });

            List<string> rows = new List<string>();

            var totalRowsProcessed = 0;
            while (totalRowsProcessed < _dataDefinition.RowCount)
            {
                StringBuilder row = new StringBuilder();
            
                foreach (var item in _outputData)
                {
                    if (row.Length == 0)
                        row.Append(item.Value[totalRowsProcessed]);
                    else
                        row.Append("," + item.Value[totalRowsProcessed]);  
                }
                
                rows.Add(row.ToString());

                totalRowsProcessed++;
            }

            return Task.FromResult(true);
        }

        static Task<bool> SaveOutput() 
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("File name: ");
            var fname = Console.Read();

            if (bool.Parse(_config["CSVPassThrough"]))
            {
                using (var writer = new StreamWriter(_config["CSVOutput"] + fname + ".csv"))
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(_outputData);
                }
            }

            return Task.FromResult(true);
        }
    }
}
