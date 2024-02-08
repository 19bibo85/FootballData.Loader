using FootballData.Loader.Enums;
using FootballData.Loader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FootballData.Loader.Loaders
{
    public sealed class FootballDataFileLoader : FootballDataLoader
    {
        #region Private Members

        private readonly string RootPath;

        #endregion

        #region Constructor

        public FootballDataFileLoader(string? rootPath) : base()
        {
            if (string.IsNullOrWhiteSpace(rootPath))
                throw new NullReferenceException($"Root path must be provided!");

            RootPath = rootPath;
        }

        #endregion

        #region Load

        public async Task<FootballDataResult<List<FootballDataEntry>>> LoadStatsAsync(FootballDataFileParams? dParams = default) => await LoadAsync(DataType.Statistics, dParams ?? new FootballDataFileParams());

        public async Task<FootballDataResult<List<FootballDataEntry>>> LoadFeaturesAsync(FootballDataFileParams? dParams = default) => await LoadAsync(DataType.Features, dParams ?? new FootballDataFileParams());

        private async Task<FootballDataResult<List<FootballDataEntry>>> LoadAsync(DataType dataType, FootballDataFileParams dParams)
        {
            return await base.Process(dataType, LoaderType.Load, dParams, Load);
        }

        private async Task<IEnumerable<FootballDataEntry>> Load(string filePath)
        {
            var fullPath = Path.Combine(RootPath, filePath);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File {fullPath} doesn't exist!");

            using StreamReader reader = new StreamReader(fullPath);
            return await base.Parser.Parse(reader);
        }

        #endregion
    }
}
