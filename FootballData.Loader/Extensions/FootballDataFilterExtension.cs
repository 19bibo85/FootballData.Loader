using FootballData.Loader.Enums;
using FootballData.Loader.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballData.Loader.Extensions
{
    internal static class FootballDataFilterExtension
    {
        internal static IEnumerable<FootballDataConfiguration> Filter(this Dictionary<Country, IEnumerable<FootballDataConfiguration>> countriesDivisions, FootballDataParams dParams)
        {
            var result = Enumerable.Empty<FootballDataConfiguration>();

            if (dParams.Country.HasValue)
            {
                result = countriesDivisions[dParams.Country.Value];
            }
            else 
            {
                result = countriesDivisions.SelectMany(s => s.Value);
            }

            return result;
        }

        internal static IEnumerable<FootballDataConfiguration> Filter(this IEnumerable<FootballDataConfiguration> footballDataConfiguration, FootballDataParams dParams)
        {
            var result = footballDataConfiguration;

            if (dParams.Country.HasValue && dParams.Division.HasValue)
            {
                result = footballDataConfiguration.Where(a => !a.Division.HasValue || a.Division == dParams.Division.Value);
            }

            if (!dParams.Country.HasValue && dParams.Division.HasValue)
            {
                result = footballDataConfiguration.Where(a => a.Division == dParams.Division.Value);
            }

            return result;
        }

        internal static IEnumerable<Dictionary<int, string>> Filter(this IEnumerable<Dictionary<int, string>> locations, FootballDataParams dParams)
        {
            var result = locations;

            if (dParams.FromYear.HasValue)
            {
                result = result.Filter(true, dParams.FromYear.Value);
            }

            if (dParams.ToYear.HasValue)
            {
                result = result.Filter(false, dParams.ToYear.Value);
            }

            return result;
        }

        private static List<Dictionary<int, string>> Filter(this IEnumerable<Dictionary<int, string>> locations, bool type, int year)
        {
            var newendpoints = new List<Dictionary<int, string>>();
            foreach (var location in locations)
            {
                if (location.ContainsKey(year) || location.ContainsKey(0))
                {
                    var newendpoint = location
                        .Where(PredicateLocations(type, year))
                        .ToDictionary(y => y.Key, e => e.Value);

                    newendpoints.Add(newendpoint);
                }
            }
            return newendpoints;
        }

        private static Func<KeyValuePair<int, string>, bool> PredicateLocations(bool type, int year) => (w) => w.Key == 0 || (type ? w.Key >= year : w.Key <= year);

        internal static IEnumerable<FootballDataEntry> Filter(this IEnumerable<FootballDataEntry> footballDataEntries, FootballDataParams dParams)
        {
            var result = footballDataEntries;

            if (dParams.Country.HasValue)
            {
                result = footballDataEntries.Where(w => !string.IsNullOrWhiteSpace(w.Div) && Configuration.CountriesDivision[dParams.Country.Value].Values.Contains(w.Div.Trim()));
            }

            if (dParams.Division.HasValue)
            {
                result = footballDataEntries.Where(w => !string.IsNullOrWhiteSpace(w.Div) && Configuration.CountriesDivision.Values.Where(w => w.ContainsKey(dParams.Division.Value)).Any(s => s.Values.Contains(w.Div.Trim())));
            }

            if (dParams.FromYear.HasValue)
            {
                result = footballDataEntries.Where(PredicateDateEntries(true, dParams.FromYear.Value));
            }

            if (dParams.ToYear.HasValue)
            {
                result = footballDataEntries.Where(PredicateDateEntries(false, dParams.ToYear.Value));
            }

            return result;
        }

        private static Func<FootballDataEntry, bool> PredicateDateEntries(bool type, int year) => (w) => w.Date.HasValue && (type ? w.Date.Value.Year >= year : w.Date.Value.Year <= year);
    }
}
