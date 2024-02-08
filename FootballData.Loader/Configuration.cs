using FootballData.Loader.Enums;
using FootballData.Loader.Models;
using System.Collections.Generic;

namespace FootballData.Loader
{
    internal static class Configuration
    {
        internal static readonly Dictionary<Country, Dictionary<Division, string>> CountriesDivision = new Dictionary<Country, Dictionary<Division, string>>()
        {
            {
                Country.England,

                new Dictionary<Division, string>()
                {
                    { Division.PremierLeague, "E0" },

                    { Division.Championship, "E1" },

                    { Division.League1, "E2" },

                    { Division.League2, "E3" },

                    { Division.Conference, "EC" }
                }
            },


            {
                Country.Scotland,

                new Dictionary<Division, string>()
                {
                    { Division.PremierLeague, "SC0" },

                    { Division.Division1, "SC1" },

                    { Division.Division2, "SC2" },

                    { Division.Division3, "SC3" },
                }
            },


            {
                Country.Germany,

                new Dictionary<Division, string>()
                {
                    { Division.Bundesliga1, "D1" },

                    { Division.Bundesliga2, "D2" }
                }
            },


            {
                Country.Italy,

                new Dictionary<Division, string>()
                {
                    { Division.SerieA, "I1" },

                    { Division.SerieB, "I2" }
                }
            },


            {
                Country.Spain,

                new Dictionary<Division, string>()
                {
                    { Division.LaLigaPrimeraDivision, "SP1" },

                    { Division.LaLigaSegundaDivision, "SP2" }
                }
            },


            {
                Country.France,

                new Dictionary<Division, string>()
                {
                    { Division.LeChampionnat, "F1" },

                    { Division.Division2, "F2" }
                }
            },


            {
                Country.Netherlands,

                new Dictionary<Division, string>()
                {
                    { Division.Eredivisie, "N1" }
                }
            },


            {
                Country.Belgium,

                new Dictionary<Division, string>()
                {
                    { Division.JupilerLeague, "B1" }
                }
            },


            {
                Country.Portugal,

                new Dictionary<Division, string>()
                {
                    { Division.LigaI, "P1" }
                }
            },


            {
                Country.Turkey,

                new Dictionary<Division, string>()
                {
                    { Division.FutbolLigi1, "T1" }
                }
            },


            {
                Country.Greece,

                new Dictionary<Division, string>()
                {
                    { Division.EthnikiKatigoria, "G1" }
                }
            },


            {
                Country.Argentina,

                new Dictionary<Division, string>()
                {
                    { Division.LigaProfesional, "Liga Profesional" }
                }
            },


            {
                Country.Austria,

                new Dictionary<Division, string>()
                {
                    { Division.Bundesliga1, "Bundesliga" }
                }
            },


            {
                Country.Brazil,

                new Dictionary<Division, string>()
                {
                    { Division.SerieA, "Serie A" }
                }
            },

            
            {
                Country.China,

                new Dictionary<Division, string>()
                {
                    { Division.SuperLeague, "Super League" }
                }
            },

            
            {
                Country.Denmark,

                new Dictionary<Division, string>()
                {
                    { Division.SuperLiga, "Super Liga" }
                }
            },

            
            {
                Country.Finland,

                new Dictionary<Division, string>()
                {
                    { Division.Veikkausliiga, "Veikkausliiga" }
                }
            },

            
            {
                Country.Ireland,

                new Dictionary<Division, string>()
                {
                    { Division.PremierLeague, "Premier Division" },

                    { Division.Division1, "Division 1" }
                }
            },

            
            {
                Country.Japan,

                new Dictionary<Division, string>()
                {
                    { Division.J1League, "J1 League" }
                }
            },

            
            {
                Country.Mexico,

                new Dictionary<Division, string>()
                {
                    { Division.LigaMX, "Liga MX" }
                }
            },

            
            {
                Country.Norway,

                new Dictionary<Division, string>()
                {
                    { Division.Eliteserien, "Eliteserien" }
                }
            },

            
            {
                Country.Poland,

                new Dictionary<Division, string>()
                {
                    { Division.Ekstraklasa, "Ekstraklasa" }
                }
            },

            
            {
                Country.Romania,

                new Dictionary<Division, string>()
                {
                    { Division.Liga1, "Liga 1" }
                }
            },


            {
                Country.Russia,

                new Dictionary<Division, string>()
                {
                    { Division.PremierLeague, "Premier League" }
                }
            },

            
            {
                Country.Sweden,

                new Dictionary<Division, string>()
                {
                    { Division.Allsvenskan, "Allsvenskan" }
                }
            },


            {
                Country.Switzerland,

                new Dictionary<Division, string>()
                {
                    { Division.SuperLeague, "Super League" }
                }
            },


            {
                Country.USA,

                new Dictionary<Division, string>()
                {
                    { Division.MLS, "MLS" }
                }
            }

        };

        internal static readonly Dictionary<Country, IEnumerable<FootballDataConfiguration>> CountriesFootballDataConfiguration = new Dictionary<Country, IEnumerable<FootballDataConfiguration>>() 
        {

            {
                Country.England,

                new List<FootballDataConfiguration>() 
                {
                    FootballDataConfiguration.Create(Country.England, Division.PremierLeague, 1993),

                    FootballDataConfiguration.Create(Country.England, Division.Championship, 1993),

                    FootballDataConfiguration.Create(Country.England, Division.League1, 1993),

                    FootballDataConfiguration.Create(Country.England, Division.League2, 1993),

                    FootballDataConfiguration.Create(Country.England, Division.Conference, 2005),
                }
            },

            
            {
                Country.Scotland,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Scotland, Division.PremierLeague, 1994),

                    FootballDataConfiguration.Create(Country.Scotland, Division.Division1, 1994),

                    FootballDataConfiguration.Create(Country.Scotland, Division.Division2, 1997),

                    FootballDataConfiguration.Create(Country.Scotland, Division.Division3, 1997)
                }
            },


            {
                Country.Germany,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Germany, Division.Bundesliga1, 1993),

                    FootballDataConfiguration.Create(Country.Germany, Division.Bundesliga2, 1993)
                }
            },


            {
                Country.Italy,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Italy, Division.SerieA, 1993),

                    FootballDataConfiguration.Create(Country.Italy, Division.SerieB, 1997)
                }
            },


            {
                Country.Spain,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Spain, Division.LaLigaPrimeraDivision, 1993),

                    FootballDataConfiguration.Create(Country.Spain, Division.LaLigaSegundaDivision, 1996)
                }
            },


            {
                Country.France,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.France, Division.LeChampionnat, 1993),

                    FootballDataConfiguration.Create(Country.France, Division.Division2, 1996)
                }
            },


            {
                Country.Netherlands,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Netherlands, Division.Eredivisie, 1993)
                }
            },


            {
                Country.Belgium,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Belgium, Division.JupilerLeague, 1995)
                }
            },


            {
                Country.Portugal,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Portugal, Division.LigaI, 1994)
                }
            },


            {
                Country.Turkey,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Turkey, Division.FutbolLigi1, 1994)
                }
            },


            {
                Country.Greece,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Greece, Division.EthnikiKatigoria, 1994)
                }
            },


            {
                Country.Argentina,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Argentina, "ARG")
                }
            },


            {
                Country.Austria,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Austria, "AUT")
                }
            },


            {
                Country.Brazil,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Brazil, "BRA")
                }
            },


            {
                Country.China,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.China, "CHN")
                }
            },


            {
                Country.Denmark,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Denmark, "DNK")
                }
            },


            {
                Country.Finland,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Finland, "FIN")
                }
            },


            {
                Country.Ireland,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Ireland, "IRL")
                }
            },


            {
                Country.Japan,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Japan, "JPN")
                }
            },


            {
                Country.Mexico,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Mexico, "MEX")
                }
            },


            {
                Country.Norway,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Norway, "NOR")
                }
            },


            {
                Country.Poland,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Poland, "POL")
                }
            },


            {
                Country.Romania,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Romania, "ROU")
                }
            },


            {
                Country.Russia,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Russia, "RUS")
                }
            },


            {
                Country.Sweden,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Sweden, "SWE")
                }
            },


            {
                Country.Switzerland,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.Switzerland, "SWZ")
                }
            },


            {
                Country.USA,

                new List<FootballDataConfiguration>()
                {
                    FootballDataConfiguration.Create(Country.USA, "USA")
                }
            }
        };
  
    }
}
