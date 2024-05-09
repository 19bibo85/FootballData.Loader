using FootballData.Loader.Enums;

namespace FootballData.Loader.Models
{
    public class FootballDataParams
    {
        public Country? Country { get; set; }

        public Division? Division { get; set; }

        public int? FromYear { get; set; }

        public int? ToYear { get; set; }
    }
}
