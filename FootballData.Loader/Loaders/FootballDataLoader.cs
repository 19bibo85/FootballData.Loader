using FootballData.Loader.Enums;
using FootballData.Loader.Extensions;
using FootballData.Loader.Models;
using FootballData.Loader.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData.Loader.Loaders
{
    public abstract class FootballDataLoader
    {
        #region Private Members

        internal readonly FootballDataParser Parser;

        internal delegate Task<IEnumerable<FootballDataEntry>> Execute(string path);

        #endregion

        #region Constructor

        protected FootballDataLoader()
        {
            Parser = FootballDataParser.Create();
        }

        #endregion

        #region Process

        internal async Task<FootballDataResult<List<FootballDataEntry>>> Process(DataType dataType, LoaderType loaderType, FootballDataParams dParams, Execute execute)
        {
            if (dParams == null)
                throw new NullReferenceException($"A {nameof(FootballDataParams)} reference must be provided!");

            var result = new FootballDataResult<List<FootballDataEntry>>() { Data = new List<FootballDataEntry>() };

            if (!TryFindLocations(dataType, loaderType, dParams, out IEnumerable<string> locations, out string errorMessage)) 
            {
                result.Success = false;
                result.Message = errorMessage;
                return result;
            }

            var errors = new StringBuilder();
            foreach (var location in locations) 
            {                    
                try
                {
                    var entriesResult = ValidateFootballDataEntries(await execute(location), dParams);
                    if (!entriesResult.Success) 
                    {
                        errors.AppendLine(entriesResult.Message);
                        result.Success = false;
                        continue;
                    }

                    if(entriesResult.Data.Any())
                        result.Data.AddRange(entriesResult.Data);
                }
                catch (Exception ex)
                {
                    errors.AppendLine(ex.ToString());
                    result.Success = false;
                }
            }
            if(errors.Length > 0)
                result.Message = errors.ToString();

            return result;
        }

        private bool TryFindLocations(DataType dataType, LoaderType loaderType, FootballDataParams dParams, out IEnumerable<string> locations, out string errorMessage) 
        {
            bool result = true;
            errorMessage = string.Empty;
            locations = Enumerable.Empty<string>();

            if (dataType == DataType.Features) 
            {
                locations = new List<string>() { "fixtures.csv" };
                return result;
            }                

            var validateCountryConfigurationResult = ValidateDivisions(Configuration.CountriesFootballDataConfiguration, dParams);
            if (!validateCountryConfigurationResult.Success) 
            {
                result = false;
                errorMessage = validateCountryConfigurationResult.Message;                
                return result;
            }                

            var validateLocationResult = ValidateLocations(validateCountryConfigurationResult.Data, loaderType, dParams);
            if (!validateLocationResult.Success) 
            {
                result = false;
                errorMessage = validateLocationResult.Message;
                return result;
            }                

            locations = validateLocationResult.Data.SelectMany(s => s.Values);

            return result;
        }

        #endregion

        #region Validations

        private FootballDataResult<IEnumerable<FootballDataConfiguration>> ValidateDivisions(Dictionary<Country, IEnumerable<FootballDataConfiguration>> countriesDivisions, FootballDataParams dParams) 
        {
            var result = new FootballDataResult<IEnumerable<FootballDataConfiguration>>();

            var footballDataDivisions = countriesDivisions.Filter(dParams);
            if (!footballDataDivisions.Any()) 
            {
                result.Success = false;
                result.Message = $"No divisions were found for country {dParams.Country}";
                return result;
            }

            footballDataDivisions = footballDataDivisions.Filter(dParams);
            if (!footballDataDivisions.Any())
            {
                result.Success = false;
                result.Message = $"{dParams.Division} was not found for country {dParams.Country}";
                return result;
            }

            result.Data = footballDataDivisions;

            return result;
        }

        private FootballDataResult<IEnumerable<Dictionary<int, string>>> ValidateLocations(IEnumerable<FootballDataConfiguration> footballDataDivisions, LoaderType loaderType, FootballDataParams dParams)
        {
            var result = new FootballDataResult<IEnumerable<Dictionary<int, string>>>();

            var locations = footballDataDivisions.Select(s => s.Locations[loaderType]);
            if (!locations.Any()) 
            {
                result.Success = false;
                result.Message = $"No {LocationName[loaderType]} were found for country {dParams.Country}";
                return result;
            }

            locations = locations.Filter(dParams);
            if (!locations.Any())
            {
                result.Success = false;
                result.Message = $"No {LocationName[loaderType]} were found in years from: {dParams.FromYear} - to: {dParams.ToYear} for country {dParams.Country}";
                return result;
            }

            result.Data = locations;

            return result;
        }

        private readonly Dictionary<LoaderType, string> LocationName = new Dictionary<LoaderType, string>
        {
            { LoaderType.Download, "endpoints" },
            { LoaderType.Load, "filenames" }
        };

        private FootballDataResult<IEnumerable<FootballDataEntry>> ValidateFootballDataEntries(IEnumerable<FootballDataEntry> footballDataEntries, FootballDataParams dParams)
        {
            var result = new FootballDataResult<IEnumerable<FootballDataEntry>>();

            footballDataEntries = footballDataEntries.Filter(dParams);
            if (!footballDataEntries.Any())
            {
                result.Success = false;
                result.Message = $"No entries were found for country: {dParams.Country} and division: {dParams.Division} in years from: {dParams.FromYear} - to: {dParams.ToYear} for country {dParams.Country}";
                return result;
            }

            result.Data = footballDataEntries;

            return result;
        }


        #endregion
    }
}
