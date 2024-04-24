using FootballData.Loader.Enums;
using FootballData.Loader.Loaders;
using FootballData.Loader.Models;
using System.Globalization;
using Xunit;

namespace FootballData.Loader.Tests
{
    public class FootballDataHttpLoaderTest
    {
        #region Private Members

        private readonly FootballDataHttpLoader Loader;
        private static readonly string DownloadPath = "output";

        #endregion

        #region Constructor

        public FootballDataHttpLoaderTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IE");

            var client = HttpLoader
                .Create()
                .WithBrowserName(string.Empty)
                .Build();            

            Loader = new FootballDataHttpLoader(client);
        }

        #endregion

        [Fact]
        public void Given_an_http_loader_When_null_Then_a_nullable_exception_is_thrown()
        {
            Assert.Throws<NullReferenceException>(() => new FootballDataHttpLoader(null));
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_a_premier_league_URL_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Division = Division.PremierLeague
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_english_premier_league_URL_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.England,
                Division = Division.PremierLeague
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_the_argentina_URL_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.Argentina
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_the_argentinan_primera_division_URL_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.Argentina,
                Division = Division.LigaProfesional
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_english_premier_league_URL_with_year_filters_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.England,
                Division = Division.PremierLeague,
                FromYear = 1996,
                ToYear = 1996,
                FilePath = DownloadPath
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.Equal(1996, result.Data[0]?.Date?.Year);
            Assert.Equal(199, result.Data.Count);
            Assert.True(File.Exists(Path.Combine(DownloadPath, "9697-E0.csv")));
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_the_argentina_URL_with_year_filters_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.Argentina,
                Division = Division.LigaProfesional,
                FromYear = 2012,
                ToYear = 2012,
                FilePath = DownloadPath
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.Equal(2012, result.Data[0]?.Date?.Year);
            Assert.Equal(188, result.Data.Count);
            Assert.True(File.Exists(Path.Combine(DownloadPath, "ARG.csv")));
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_a_wrong_serie_a_URL_Then_a_list_of_football_data_entries_is_not_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.England,
                Division = Division.SerieA
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotEqual("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.Empty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_english_premier_league_URL_with_a_wrong_year_filters_Then_a_list_of_football_data_entries_is_not_returned()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.England,
                Division = Division.PremierLeague,
                FromYear = int.MaxValue,
                ToYear = int.MinValue
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotEqual("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.Empty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_a_serie_a_file_Then_the_first_football_entry_is_valid()
        {
            var param = new FootballDataHttpParams()
            {
                Country = Country.Argentina,
                FromYear = 2012,
                ToYear = 2012
            };

            var result = await Loader.DownloadStatsAsync(param);

            Assert.Equal("Liga Profesional", result.Data[0].Div);
            Assert.Equal(DateTime.Parse("03/08/2012"), result.Data[0].Date);
            Assert.Equal("23:00", result.Data[0].Time);
            Assert.Equal("Arsenal Sarandi", result.Data[0].HomeTeam);
            Assert.Equal("Union de Santa Fe", result.Data[0].AwayTeam);
            Assert.Equal(1, result.Data[0].FTHG);
            Assert.Equal(0, result.Data[0].FTAG);
            Assert.Equal("H", result.Data[0].FTR);
            Assert.Equal(1.9m, result.Data[0].PH);
            Assert.Equal(3.39m, result.Data[0].PD);
            Assert.Equal(5.03m, result.Data[0].PA);
            Assert.Equal(1.9m, result.Data[0].MaxH);
            Assert.Equal(3.5m, result.Data[0].MaxD);
            Assert.Equal(5.68m, result.Data[0].MaxA);
            Assert.Equal(1.76m, result.Data[0].AvgH);
            Assert.Equal(3.3m, result.Data[0].AvgD);
            Assert.Equal(4.74m, result.Data[0].AvgA);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_a_fixtures_file_Then_a_list_of_football_data_entries_is_returned()
        {
            var result = await Loader.DownloadFeaturesAsync();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Given_an_http_loader_When_parsing_a_fixtures_file_Then_a_list_of_football_data_entries_is_returned_and_file_saved()
        {
            var param = new FootballDataHttpParams() 
            {
                FilePath = DownloadPath
            };

            var result = await Loader.DownloadFeaturesAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.True(File.Exists(Path.Combine(DownloadPath, "fixtures.csv")));
        }
    }
}
