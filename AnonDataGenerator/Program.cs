using AnonDataGenerator.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;

namespace AnonDataGenerator
{
    class Program
    {
        private static IConfiguration _config;
        private static DataDefinition _dataDefinition { get; set; }

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder().AddJsonFile("Settings.json", false, true).Build();


            string dataFormatContent = File.ReadAllText(_config["DataFormatPath"]);

            _dataDefinition = JsonConvert.DeserializeObject<DataDefinition>(dataFormatContent);

            var count = 1;
            _dataDefinition.ColumnDefinitions.ForEach(x => {
                Console.WriteLine($"{count}) {x.ColumnName}");
                count++;
                });


            await ProcessDataDefinition(_dataDefinition);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Data Generated");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Press any key to exit!");
            Console.Read();
        }

        static async Task ProcessDataDefinition(DataDefinition dd) 
        {
            return;
        }
    }
}
