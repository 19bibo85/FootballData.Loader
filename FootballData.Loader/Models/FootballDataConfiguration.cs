using FootballData.Loader.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballData.Loader.Models
{
    internal class FootballDataConfiguration
    {
        internal readonly Dictionary<LoaderType, Dictionary<int, string>> Locations = new Dictionary<LoaderType, Dictionary<int, string>>();

        private FootballDataConfiguration(Country country, Division? division, string segmentName, int? minimumYear) 
        {
            Country = country;
            Division = division;
            SegmentName = segmentName;
            MinimumYear = minimumYear;

            var endpoints = new Dictionary<int, string>();
            var filenames = new Dictionary<int, string>();
            if (!minimumYear.HasValue)
            {
                endpoints.Add(0, $"{Global.FootballDataOtherSegment}/{SegmentName}.csv");
                filenames.Add(0, $"{SegmentName}.csv");
            }
            else 
            {
                var years = Enumerable.Range(minimumYear.Value, DateTime.Now.Year - minimumYear.Value);
                endpoints = years.ToDictionary(y => y, e => $"{Global.FootballDataEuropeSegment}/{e.ToString().Substring(2, 2)}{(e + 1).ToString().Substring(2, 2)}/{SegmentName}.csv");
                filenames = years.ToDictionary(y => y, e => $"{e.ToString().Substring(2, 2)}{(e + 1).ToString().Substring(2, 2)}-{SegmentName}.csv");
            }

            Locations.Add(LoaderType.Download, endpoints);
            Locations.Add(LoaderType.Load, filenames);
        }   

        internal static FootballDataConfiguration Create(Country country, string segmentName) => new FootballDataConfiguration(country, null, segmentName, null);

        internal static FootballDataConfiguration Create(Country country, Division division, int? minimumYear) => new FootballDataConfiguration(country, division, Configuration.CountriesDivision[country][division], minimumYear);

        internal Country Country { get; }

        internal Division? Division { get; }

        internal string SegmentName { get; }

        internal int? MinimumYear { get; }
    }
}
