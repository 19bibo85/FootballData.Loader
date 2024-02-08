using FootballData.Loader.Enums;
using FootballData.Loader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballData.Loader.Loaders
{
    public sealed class FootballDataHttpLoader : FootballDataLoader
    {
        #region Private Members

        private readonly HttpClient Client;
        private FootballDataHttpParams? DParams;

        #endregion

        #region Constructor

        public FootballDataHttpLoader(HttpClient? client) : base()
        {
            if (client == null)
                throw new NullReferenceException($"A {nameof(HttpClient)} reference must be provided!");

            Client = client;
        }

        #endregion

        #region Download

        public async Task<FootballDataResult<List<FootballDataEntry>>> DownloadStatsAsync(FootballDataHttpParams? dParams = default) => await DownloadAsync(DataType.Statistics, dParams ?? new FootballDataHttpParams());

        public async Task<FootballDataResult<List<FootballDataEntry>>> DownloadFeaturesAsync(FootballDataHttpParams? dParams = default) => await DownloadAsync(DataType.Features, dParams ?? new FootballDataHttpParams());

        private async Task<FootballDataResult<List<FootballDataEntry>>> DownloadAsync(DataType dataType, FootballDataHttpParams dParams)
        {
            DParams = dParams;
            return await base.Process(dataType, LoaderType.Download, dParams, Download);
        }

        private async Task<IEnumerable<FootballDataEntry>> Download(string endpoint)
        {
            using HttpResponseMessage response = await Client.GetAsync($"{Global.FootballDataEndpoint}/{endpoint}");
            using Stream stream = await response.Content.ReadAsStreamAsync();
            using StreamReader reader = new StreamReader(stream);
            await DownloadFile(reader, endpoint);
            return await base.Parser.Parse(reader);
        }

        private readonly Dictionary<string, string> SegementReplacements = new Dictionary<string, string>() 
        {
            { $"{Global.FootballDataEndpoint}/", string.Empty },
            { $"{Global.FootballDataEuropeSegment}/", string.Empty },
            { $"{Global.FootballDataOtherSegment}/", string.Empty },
            { "/", "-" }
        };

        private async Task DownloadFile(StreamReader reader, string endpoint)
        {
            if (string.IsNullOrWhiteSpace(endpoint) || string.IsNullOrWhiteSpace(DParams?.FilePath))
                return;

            if(!Directory.Exists(DParams.FilePath))
                Directory.CreateDirectory(DParams.FilePath);

            var filename = endpoint;
            foreach (var segementReplacement in SegementReplacements) 
            {
                filename = filename.Replace(segementReplacement.Key, segementReplacement.Value);
            }

            if (string.IsNullOrWhiteSpace(filename))
                return;

            reader.BaseStream.Position = 0;
            using StreamWriter writer = new StreamWriter(Path.Combine(DParams.FilePath, filename));
            writer.WriteLine(await reader.ReadToEndAsync());
        }

        #endregion
    }
}
