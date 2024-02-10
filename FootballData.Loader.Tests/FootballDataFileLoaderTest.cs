using FootballData.Loader.Enums;
using FootballData.Loader.Loaders;
using FootballData.Loader.Models;
using Xunit;

namespace FootballData.Loader.Tests
{
    public class FootballDataFileLoaderTest
    {
        #region Private Members

        private readonly FootballDataFileLoader Loader;

        #endregion

        #region Constructor

        public FootballDataFileLoaderTest()
        {
            Loader = new FootballDataFileLoader("resources");
        }

        #endregion

        [Fact]
        public void Given_a_file_path_When_null_Then_a_nullable_expection_is_raised()
        {
            Assert.Throws<NullReferenceException>(() => new FootballDataFileLoader(null));
        }

        [Fact]
        public async Task Given_a_file_loader_When_parsing_a_serie_a_file_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataFileParams()
            {
                Country = Country.Italy,
                Division = Division.SerieA,
                FromYear = 2013,
                ToYear = 2013
            };

            var result = await Loader.LoadStatsAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Given_a_file_loader_When_parsing_a_serie_a_file_Then_the_first_football_entry_is_valid()
        {
            var param = new FootballDataFileParams()
            {
                Country = Country.Italy,
                Division = Division.SerieA,
                FromYear = 2013,
                ToYear = 2013
            };

            var result = await Loader.LoadStatsAsync(param);

            Assert.Equal("I1", result.Data[0].Div);
            Assert.Equal(DateTime.Parse("24/08/13"), result.Data[0].Date);
            Assert.Equal("Sampdoria", result.Data[0].HomeTeam);
            Assert.Equal("Juventus", result.Data[0].AwayTeam);
            Assert.Equal(0, result.Data[0].FTHG);
            Assert.Equal(1, result.Data[0].FTAG);
            Assert.Equal("A", result.Data[0].FTR);
            Assert.Equal(0, result.Data[0].HTHG);
            Assert.Equal(0, result.Data[0].HTAG);
            Assert.Equal("D", result.Data[0].HTR);
            Assert.Equal(4, result.Data[0].HS);
            Assert.Equal(11, result.Data[0].AS);
            Assert.Equal(1, result.Data[0].HST);
            Assert.Equal(4, result.Data[0].AST);
            Assert.Equal(21, result.Data[0].HF);
            Assert.Equal(21, result.Data[0].AF);
            Assert.Equal(4, result.Data[0].HCR);
            Assert.Equal(10, result.Data[0].AC);
            Assert.Equal(2, result.Data[0].HY);
            Assert.Equal(3, result.Data[0].AY);
            Assert.Equal(1, result.Data[0].HR);
            Assert.Equal(0, result.Data[0].AR);
            Assert.Equal(8.0m, result.Data[0].B365H);
            Assert.Equal(4.0m, result.Data[0].B365D);
            Assert.Equal(1.45m, result.Data[0].B365A);
            Assert.Equal(7.25m, result.Data[0].BWH);
            Assert.Equal(4.0m, result.Data[0].BWD);
            Assert.Equal(1.48m, result.Data[0].BWA);
            Assert.Equal(5.5m, result.Data[0].IWH);
            Assert.Equal(4.0m, result.Data[0].IWD);
            Assert.Equal(1.55m, result.Data[0].IWA);
            Assert.Equal(6.0m, result.Data[0].LBH);
            Assert.Equal(4.0m, result.Data[0].LBD);
            Assert.Equal(1.53m, result.Data[0].LBA);
            Assert.Equal(7.94m, result.Data[0].PH);
            Assert.Equal(4.02m, result.Data[0].PD);
            Assert.Equal(1.55m, result.Data[0].PA);
            Assert.Equal(7.0m, result.Data[0].WHH);
            Assert.Equal(4.0m, result.Data[0].WHD);
            Assert.Equal(1.5m, result.Data[0].WHA);
            Assert.Equal(7.5m, result.Data[0].SJH);
            Assert.Equal(3.8m, result.Data[0].SJD);
            Assert.Equal(1.44m, result.Data[0].SJA);
            Assert.Equal(7.5m, result.Data[0].VCH);
            Assert.Equal(4.0m, result.Data[0].VCD);
            Assert.Equal(1.55m, result.Data[0].VCA);
            Assert.Equal(32.0m, result.Data[0].Bb1X2);
            Assert.Equal(8.1m, result.Data[0].BbMxH);
            Assert.Equal(6.96m, result.Data[0].BbAvH);
            Assert.Equal(4.33m, result.Data[0].BbMxD);
            Assert.Equal(3.98m, result.Data[0].BbAvD);
            Assert.Equal(1.55m, result.Data[0].BbMxA);
            Assert.Equal(1.5m, result.Data[0].BbAvA);
            Assert.Equal(30.0m, result.Data[0].BbOU);
            Assert.Equal(2.08m, result.Data[0].BbMxOver2Pt5);
            Assert.Equal(2.0m, result.Data[0].BbAvOver2Pt5);
            Assert.Equal(1.9m, result.Data[0].BbMxUnder2Pt5);
            Assert.Equal(1.8m, result.Data[0].BbAvUnder2Pt5);
            Assert.Equal(19.0m, result.Data[0].BbAH);
            Assert.Equal(1.0m, result.Data[0].BbAHh);
            Assert.Equal(2.09m, result.Data[0].BbMxAHH);
            Assert.Equal(2.04m, result.Data[0].BbAvAHH);
            Assert.Equal(1.88m, result.Data[0].BbMxAHA);
            Assert.Equal(1.83m, result.Data[0].BbAvAHA);
        }

        [Fact]
        public async Task Given_a_file_loader_When_parsing_a_not_existing_serie_a_file_Then_a_list_of_football_data_entries_is_not_returned()
        {
            var param = new FootballDataFileParams()
            {
                Country = Country.Italy,
                Division = Division.SerieA,
                FromYear = 2014,
                ToYear = 2014
            };

            var result = await Loader.LoadStatsAsync(param);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotEqual("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.Empty(result.Data);
        }


        [Fact]
        public async Task Given_a_file_loader_When_parsing_a_fixture_file_Then_a_list_of_football_data_entries_is_returned()
        {
            var param = new FootballDataFileParams()
            {     
                Country = Country.Germany
            };

            var result = await Loader.LoadFeaturesAsync(param);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal("OK", result.Message);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.Equal("D1", result.Data[0].Div);
            Assert.Equal(DateTime.Parse("07/02/24"), result.Data[0].Date);
            Assert.Equal("17:30", result.Data[0].Time);
            Assert.Equal("Mainz", result.Data[0].HomeTeam);
            Assert.Equal("Union Berlin", result.Data[0].AwayTeam);
        }
    }
}
