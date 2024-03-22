using FootballData.Loader.Enums;
using FootballData.Loader.Errors;
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

        #endregion

        #region Constructor

        protected FootballDataLoader()
        {
            Parser = FootballDataParser.Create();
        }

        #endregion

        #region Process

        internal async Task<FootballDataResult<List<FootballDataEntry>>> Process(DataType dataType, LoaderType loaderType, FootballDataParams dParams)
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
                    var entriesResult = ValidateFootballDataEntries(await LoadFootballDataEntries(location, dParams), dParams);
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

            var validateCountriesConfigurationResult = ValidateCountriesConfiguration(Configuration.CountriesFootballDataConfiguration, dParams);
            if (!validateCountriesConfigurationResult.Success) 
            {
                result = false;
                errorMessage = validateCountriesConfigurationResult.Message;                
                return result;
            }                

            var validateLocationResult = ValidateLocations(validateCountriesConfigurationResult.Data, loaderType, dParams);
            if (!validateLocationResult.Success) 
            {
                result = false;
                errorMessage = validateLocationResult.Message;
                return result;
            }                

            locations = validateLocationResult.Data.SelectMany(s => s.Values);

            return result;
        }

        protected abstract Task<IEnumerable<FootballDataEntry>> LoadFootballDataEntries(string path, FootballDataParams dParams);

        #endregion

        #region Validations

        private FootballDataResult<IEnumerable<FootballDataConfiguration>> ValidateCountriesConfiguration(Dictionary<Country, IEnumerable<FootballDataConfiguration>> countryConfiguration, FootballDataParams dParams) 
        {
            var result = new FootballDataResult<IEnumerable<FootballDataConfiguration>>();            

            var configuration = countryConfiguration.Filter(dParams);
            if (!configuration.Any()) 
            {
                result.Success = false;
                result.Message = FootballDataFilterError.Errors(ErrorKeys.FilterCountry, dParams);
                return result;
            }

            configuration = configuration.Filter(dParams);
            if (!configuration.Any())
            {
                result.Success = false;
                result.Message = FootballDataFilterError.Errors(ErrorKeys.FilterConfiguration, dParams);
                return result;
            }

            result.Data = configuration;

            return result;
        }

        private FootballDataResult<IEnumerable<Dictionary<int, string>>> ValidateLocations(IEnumerable<FootballDataConfiguration> footballDataDivisions, LoaderType loaderType, FootballDataParams dParams)
        {
            var result = new FootballDataResult<IEnumerable<Dictionary<int, string>>>();

            var locations = footballDataDivisions.Select(s => s.Locations[loaderType]);
            if (!locations.Any()) 
            {
                result.Success = false;
                result.Message = FootballDataFilterError.Errors(ErrorKeys.FilterLocation1, dParams);
                return result;
            }

            locations = locations.Filter(dParams);
            if (!locations.Any())
            {
                result.Success = false;
                result.Message = FootballDataFilterError.Errors(ErrorKeys.FilterLocation2, dParams);
                return result;
            }

            result.Data = locations;

            return result;
        }

        private FootballDataResult<IEnumerable<FootballDataEntry>> ValidateFootballDataEntries(IEnumerable<FootballDataEntry> footballDataEntries, FootballDataParams dParams)
        {
            var result = new FootballDataResult<IEnumerable<FootballDataEntry>>();

            footballDataEntries = footballDataEntries.Filter(dParams);
            if (!footballDataEntries.Any())
            {
                result.Success = false;
                result.Message = FootballDataFilterError.Errors(ErrorKeys.FilterEntry, dParams);
                return result;
            }

            result.Data = footballDataEntries;

            return result;
        }

        #endregion
    }
}
