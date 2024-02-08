using FootballData.Loader.Attributes;
using FootballData.Loader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballData.Loader.Parsers
{
    internal class FootballDataParser
    {
        private const char Separator = ',';

        private readonly Dictionary<string,string> FootballDataEntryMapping = new Dictionary<string,string>();

        private FootballDataParser() 
        {
            var properties = Activator.CreateInstance(typeof(FootballDataEntry))
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var property in properties) 
            {
                if (string.IsNullOrWhiteSpace(property.Name))
                    continue;

                var columnNames = property.GetCustomAttribute<ColumnNameAttribute>()?.Names?.Split(Separator) ?? new string[1] { property.Name };
                foreach (var columnName in columnNames) 
                {
                    if (FootballDataEntryMapping.ContainsKey(columnName))
                        continue;

                    FootballDataEntryMapping.Add(columnName, property.Name);
                }
            }
        }

        internal static FootballDataParser Create() => new FootballDataParser();

        internal async Task<IEnumerable<FootballDataEntry>> Parse(StreamReader stream) 
        {
            stream.BaseStream.Position = 0;

            var entries = new List<FootballDataEntry>();

            Dictionary<int, string> footballDataEntryIndexing = new Dictionary<int, string>();

            int i = 0;
            while (!stream.EndOfStream) 
            {
                try
                {
                    var line = await stream.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // header
                    if (i == 0)
                    {
                        var headerColumns = line.Split(Separator);
                        for (int j = 0; j < headerColumns.Length; j++)
                        {
                            if (string.IsNullOrWhiteSpace(headerColumns[j]))
                                continue;

                            if (!FootballDataEntryMapping.ContainsKey(headerColumns[j].Trim()))
                                continue;

                            footballDataEntryIndexing.Add(j, headerColumns[j]);
                        }
                        continue;
                    }

                    // no columns in the header
                    if (footballDataEntryIndexing.Count() == 0)
                        continue;

                    // data
                    var entry = CreateFootballDataEntry(line, footballDataEntryIndexing);
                    if (entry == null)
                        continue;

                    entries.Add(entry);
                }
                finally 
                {
                    i++;
                }
            }

            return entries;
        }

        private FootballDataEntry? CreateFootballDataEntry(string line, Dictionary<int, string> footballDataEntryIndexing) 
        {
            FootballDataEntry? entry = null;

            var dataColumns = line.Split(Separator);
            for (int j = 0; j < dataColumns.Length; j++)
            {
                try
                {
                    if (!footballDataEntryIndexing.ContainsKey(j))
                        continue;

                    var headerColumn = footballDataEntryIndexing[j];
                    if (!FootballDataEntryMapping.ContainsKey(headerColumn))
                        continue;

                    var propertyName = FootballDataEntryMapping[headerColumn];
                    if (string.IsNullOrWhiteSpace(propertyName))
                        continue;

                    if (entry == null)
                        entry = new FootballDataEntry();

                    entry
                        .GetType()
                        .GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic)
                        .SetValue(entry, dataColumns[j]);
                }
                catch 
                {
                    entry = null;
                }
            }

            return entry;
        }
    }
}
