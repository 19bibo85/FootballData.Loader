using FootballData.Loader.Models;
using System;
using System.Collections.Generic;

namespace FootballData.Loader.Errors
{
    internal static class FootballDataFilterError
    {
        private readonly static Dictionary<string, Func<FootballDataParams, string>> ErrorParamsMessages = new Dictionary<string, Func<FootballDataParams, string>>()
        {
            { nameof(FootballDataParams.Country), (dParams) => dParams.Country.HasValue ? $" for country {dParams.Country}" : string.Empty },

            { nameof(FootballDataParams.Division), (dParams) => dParams.Division.HasValue ? $" for division {dParams.Division}" : string.Empty },

            { nameof(FootballDataParams.FromYear), (dParams) => dParams.FromYear.HasValue ?  $" from year: {dParams.FromYear}" : string.Empty },

            { nameof(FootballDataParams.ToYear), (dParams) => dParams.ToYear.HasValue ?  $" to year: {dParams.ToYear}" : string.Empty }
        };

        private readonly static Func<string, FootballDataParams, string> ErrorParams = (error, dParams) => ErrorParamsMessages.ContainsKey(error) ? ErrorParamsMessages[error](dParams) : string.Empty;

        private readonly static Dictionary<string, Func<FootballDataParams, string>> ErrorMessages = new Dictionary<string, Func<FootballDataParams, string>>()
        {
            { ErrorKeys.FilterCountry, (dParams) => $"No divisions were found{ErrorParams(nameof(FootballDataParams.Country), dParams)}" },

            { ErrorKeys.FilterConfiguration, (dParams) => $"No configurations were found{ErrorParams(nameof(FootballDataParams.Division), dParams)}{ErrorParams(nameof(FootballDataParams.Country), dParams)}" },

            { ErrorKeys.FilterLocation1, (dParams) => $"No locations were found{ErrorParams(nameof(FootballDataParams.Country), dParams)}" },

            { ErrorKeys.FilterLocation2, (dParams) => $"No locations were found{ErrorParams(nameof(FootballDataParams.FromYear), dParams)}{ErrorParams(nameof(FootballDataParams.ToYear), dParams)}{ErrorParams(nameof(FootballDataParams.Country), dParams)}" },

            { ErrorKeys.FilterEntry, (dParams) => $"No entries were found{ErrorParams(nameof(FootballDataParams.Country), dParams)}{ErrorParams(nameof(FootballDataParams.Division), dParams)}{ErrorParams(nameof(FootballDataParams.FromYear), dParams)}{ErrorParams(nameof(FootballDataParams.ToYear), dParams)}" }
        };

        internal readonly static Func<string, FootballDataParams, string> Errors = (error, dParams) => ErrorMessages.ContainsKey(error) ? ErrorMessages[error](dParams) : string.Empty;
    }
}
