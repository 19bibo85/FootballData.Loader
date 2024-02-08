using FootballData.Loader.Attributes;
using System;

namespace FootballData.Loader.Models
{
    // https://www.football-data.co.uk/notes.txt
    public class FootballDataEntry
    {
        /// <summary>
        /// Division
        /// </summary>
        [ColumnName("Div,League")]
        private string? DivRaw { get; set; }

        public string? Div => DivRaw?.Trim();

        /// <summary>
        /// Date
        /// </summary>
        [ColumnName("Date")]
        private string? DateRaw { get; set; }

        public DateTime? Date => DateTime.TryParse(DateRaw?.Trim(), out var value) ? (DateTime?)value : null;

        /// <summary>
        /// Time
        /// </summary>
        [ColumnName("Time")]
        private string? TimeRaw { get; set; }

        public string? Time => TimeRaw?.Trim();

        /// <summary>
        /// HomeTeam
        /// </summary>
        [ColumnName("HomeTeam,Home")]
        private string? HomeTeamRaw { get; set; }

        public string? HomeTeam => HomeTeamRaw?.Trim();

        /// <summary>
        /// AwayTeam
        /// </summary>
        [ColumnName("AwayTeam,Away")]
        private string? AwayTeamRaw { get; set; }

        public string? AwayTeam => AwayTeamRaw?.Trim();

        /// <summary>
        /// FullTimeHomeGoal
        /// </summary>
        [ColumnName("FTHG,HG")]
        private string? FTHGRaw { get; set; }

        public int? FTHG => int.TryParse(FTHGRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// FullTimeAwayGoal
        /// </summary>
        [ColumnName("FTAG,AG")]
        private string? FTAGRaw { get; set; }

        public int? FTAG => int.TryParse(FTAGRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// FullTimeResult
        /// </summary>
        [ColumnName("FTR,Res")]
        private string? FTRRaw { get; set; }

        public string? FTR => FTRRaw?.Trim();

        /// <summary>
        /// HalfTimeHomeGoal
        /// </summary>
        [ColumnName("HTHG")]
        private string? HTHGRaw { get; set; }

        public int? HTHG => int.TryParse(HTHGRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HalfTimeAwayGoal
        /// </summary>
        [ColumnName("HTAG")]
        private string? HTAGRaw { get; set; }

        public int? HTAG => int.TryParse(HTAGRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HalfTimeResult
        /// </summary>
        [ColumnName("HTR")]
        private string? HTRRaw { get; set; }

        public string? HTR => HTRRaw?.Trim();

        /// <summary>
        /// Attendance
        /// </summary>
        [ColumnName("Attendance")]
        private string? AttendanceRaw { get; set; }

        public int? Attendance => int.TryParse(AttendanceRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// Referee
        /// </summary>
        [ColumnName("Referee")]
        private string? RefereeRaw { get; set; }

        public string? Referee => RefereeRaw?.Trim();

        /// <summary>
        /// HomeTeamShot
        /// </summary>
        [ColumnName("HS")]
        private string? HSRaw { get; set; }

        public int? HS => int.TryParse(HSRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamShotRaw
        /// </summary>
        [ColumnName("AS")]
        private string? ASRaw { get; set; }

        public int? AS => int.TryParse(ASRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamShotOnTarget
        /// </summary>
        [ColumnName("HST")]
        private string? HSTRaw { get; set; }

        public int? HST => int.TryParse(HSTRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamShotOnTarget
        /// </summary>
        [ColumnName("AST")]
        private string? ASTRaw { get; set; }

        public int? AST => int.TryParse(ASTRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamHitWoodwork
        /// </summary>
        [ColumnName("HHW")]
        private string? HHWRaw { get; set; }

        public int? HHW => int.TryParse(HHWRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamHitWoodworkRaw
        /// </summary>
        [ColumnName("AHW")]
        private string? AHWRaw { get; set; }

        public int? AHW => int.TryParse(AHWRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamCorners
        /// </summary>
        [ColumnName("HC")]
        private string? HCRaw { get; set; }

        public int? HCR => int.TryParse(HCRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamCorners
        /// </summary>
        [ColumnName("AC")]
        private string? ACRaw { get; set; }

        public int? AC => int.TryParse(ACRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamFoulsCommitted
        /// </summary>
        [ColumnName("HF")]
        private string? HFRaw { get; set; }

        public int? HF => int.TryParse(HFRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamFoulsCommitted
        /// </summary>
        [ColumnName("AF")]
        private string? AFRaw { get; set; }

        public int? AF => int.TryParse(AFRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamFreeKicksConceded
        /// </summary>
        [ColumnName("HFKC")]
        private string? HFKCRaw { get; set; }

        public int? HFKC => int.TryParse(HFKCRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamFreeKicksConceded
        /// </summary>
        [ColumnName("AFKC")]
        private string? AFKCRaw { get; set; }

        public int? AFKC => int.TryParse(AFKCRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamOffsides
        /// </summary>
        [ColumnName("HO")]
        private string? HORaw { get; set; }

        public int? HO => int.TryParse(HORaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamOffsides
        /// </summary>
        [ColumnName("AO")]
        private string? AORaw { get; set; }

        public int? AO => int.TryParse(AORaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamYellowCards
        /// </summary>
        [ColumnName("HY")]
        private string? HYRaw { get; set; }

        public int? HY => int.TryParse(HYRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamYellowCards
        /// </summary>
        [ColumnName("AY")]
        private string? AYRaw { get; set; }

        public int? AY => int.TryParse(AYRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamRedCards
        /// </summary>
        [ColumnName("HR")]
        private string? HRRaw { get; set; }

        public int? HR => int.TryParse(HRRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// AwayTeamRedCards
        /// </summary>
        [ColumnName("AR")]
        private string? ARRaw { get; set; }

        public int? AR => int.TryParse(ARRaw?.Trim(), out var value) ? (int?)value : null;

        /// <summary>
        /// HomeTeamBookingsPoints
        /// </summary>
        [ColumnName("HBP")]
        private string? HBPRaw { get; set; }

        public decimal? HBP => decimal.TryParse(HBPRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// AwayTeamBookingsPoints
        /// </summary>
        [ColumnName("ABP")]
        private string? ABPRaw { get; set; }

        public decimal? ABP => decimal.TryParse(ABPRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365HomeWinOdds
        /// </summary>
        [ColumnName("B365H")]
        private string? B365HRaw { get; set; }

        public decimal? B365H => decimal.TryParse(B365HRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365DrawOdds
        /// </summary>
        [ColumnName("B365D")]
        private string? B365DRaw { get; set; }

        public decimal? B365D => decimal.TryParse(B365DRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365AwayWinOdds
        /// </summary>
        [ColumnName("B365A")]
        private string? B365ARaw { get; set; }

        public decimal? B365A => decimal.TryParse(B365ARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BlueSquareHomeWinOdds
        /// </summary>
        [ColumnName("BSH")]
        private string? BSHRaw { get; set; }

        public decimal? BSH => decimal.TryParse(BSHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BlueSquareDrawOdds
        /// </summary>
        [ColumnName("BSD")]
        private string? BSDRaw { get; set; }

        public decimal? BSDOdds => decimal.TryParse(BSDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BlueSquareAwayWinOdds
        /// </summary>
        [ColumnName("BSA")]
        private string? BSARaw { get; set; }

        public decimal? BSA => decimal.TryParse(BSARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetAndWinHomeWinOdds
        /// </summary>
        [ColumnName("BWH")]
        private string? BWHRaw { get; set; }

        public decimal? BWH => decimal.TryParse(BWHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetAndWinDrawOdds
        /// </summary>
        [ColumnName("BWD")]
        private string? BWDRaw { get; set; }

        public decimal? BWD => decimal.TryParse(BWDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetAndWinAwayWinOdds
        /// </summary>
        [ColumnName("BWA")]
        private string? BWARaw { get; set; }

        public decimal? BWA => decimal.TryParse(BWARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersHomeWinOdds
        /// </summary>
        [ColumnName("GBH")]
        private string? GBHRaw { get; set; }

        public decimal? GBH => decimal.TryParse(GBHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersDrawOdds
        /// </summary>
        [ColumnName("GBD")]
        private string? GBDRaw { get; set; }

        public decimal? GBD => decimal.TryParse(GBDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersAwayWinOdds
        /// </summary>
        [ColumnName("GBA")]
        private string? GBARaw { get; set; }

        public decimal? GBA => decimal.TryParse(GBARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// InterwettenHomeWinOdds
        /// </summary>
        [ColumnName("IWH")]
        private string? IWHRaw { get; set; }

        public decimal? IWH => decimal.TryParse(IWHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// InterwettenDrawOdds
        /// </summary>
        [ColumnName("IWD")]
        private string? IWDRaw { get; set; }

        public decimal? IWD => decimal.TryParse(IWDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// InterwettenAwayWinOdds
        /// </summary>
        [ColumnName("IWA")]
        private string? IWARaw { get; set; }

        public decimal? IWA => decimal.TryParse(IWARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// LadbrokesHomeWinOdds
        /// </summary>
        [ColumnName("LBH")]
        private string? LBHRaw { get; set; }

        public decimal? LBH => decimal.TryParse(LBHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// LadbrokesDrawOddsRaw
        /// </summary>
        [ColumnName("LBD")]
        private string? LBDRaw { get; set; }

        public decimal? LBD => decimal.TryParse(LBDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// LadbrokesAwayWinOdds
        /// </summary>
        [ColumnName("LBA")]
        private string? LBARaw { get; set; }

        public decimal? LBA => decimal.TryParse(LBARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleHomeWinOdds
        /// </summary>
        [ColumnName("PSH,PH")]
        private string? PHRaw { get; set; }

        public decimal? PH => decimal.TryParse(PHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleDrawOdds
        /// </summary>
        [ColumnName("PSD,PD")]
        private string? PDRaw { get; set; }

        public decimal? PD => decimal.TryParse(PDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleAwayWinOdds
        /// </summary>
        [ColumnName("PSA,PA")]
        private string? PARaw { get; set; }

        public decimal? PA => decimal.TryParse(PARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// SportingOddsHomeWinOdds
        /// </summary>
        [ColumnName("SOH")]
        private string? SOHRaw { get; set; }

        public decimal? SOH => decimal.TryParse(SOHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// SportingOddsDrawOdds
        /// </summary>
        [ColumnName("SOD")]
        private string? SODRaw { get; set; }

        public decimal? SOD => decimal.TryParse(SODRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// SportingOddsAwayWinOdds
        /// </summary>
        [ColumnName("SOA")]
        private string? SOARaw { get; set; }

        public decimal? SOA => decimal.TryParse(SOARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// SportingbetHomeWinOdds
        /// </summary>
        [ColumnName("SBH")]
        private string? SBHRaw { get; set; }

        public decimal? SBH => decimal.TryParse(SBHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// SportingbetHomeWinOdds
        /// </summary>
        [ColumnName("SBD")]
        private string? SBDRaw { get; set; }

        public decimal? SBD => decimal.TryParse(SBDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// SportingbetAwayWinOdds
        /// </summary>
        [ColumnName("SBA")]
        private string? SBARaw { get; set; }

        public decimal? SBA => decimal.TryParse(SBARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// StanJamesHomeWinOdds
        /// </summary>
        [ColumnName("SJH")]
        private string? SJHRaw { get; set; }

        public decimal? SJH => decimal.TryParse(SJHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// StanJamesDrawOdds
        /// </summary>
        [ColumnName("SJD")]
        private string? SJDRaw { get; set; }

        public decimal? SJD => decimal.TryParse(SJDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// StanJamesAwayWinOdds
        /// </summary>
        [ColumnName("SJA")]
        private string? SJARaw { get; set; }

        public decimal? SJA => decimal.TryParse(SJARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// StanleybetHomeWinOdds
        /// </summary>
        [ColumnName("SYH")]
        private string? SYHRaw { get; set; }

        public decimal? SYH => decimal.TryParse(SYHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// StanleybetDrawOdds
        /// </summary>
        [ColumnName("SYD")]
        private string? SYDRaw { get; set; }

        public decimal? SYD => decimal.TryParse(SYDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// StanleybetAwayWinOdds
        /// </summary>
        [ColumnName("SYA")]
        private string? SYARaw { get; set; }

        public decimal? SYA => decimal.TryParse(SYARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// VCBetHomeWinOdds
        /// </summary>
        [ColumnName("VCH")]
        private string? VCHRaw { get; set; }

        public decimal? VCH => decimal.TryParse(VCHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// VCBetDrawOdds
        /// </summary>
        [ColumnName("VCD")]
        private string? VCDRaw { get; set; }

        public decimal? VCD => decimal.TryParse(VCDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// VCBetAwayWinOdds
        /// </summary>
        [ColumnName("VCA")]
        private string? VCARaw { get; set; }

        public decimal? VCA => decimal.TryParse(VCARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// WilliamHillHomeWinOdds
        /// </summary>
        [ColumnName("WHH")]
        private string? WHHRaw { get; set; }

        public decimal? WHH => decimal.TryParse(WHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// WilliamHillDrawOdds
        /// </summary>
        [ColumnName("WHD")]
        private string? WHDRaw { get; set; }

        public decimal? WHD => decimal.TryParse(WHDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// WilliamHillAwayWinOdds
        /// </summary>
        [ColumnName("WHA")]
        private string? WHARaw { get; set; }

        public decimal? WHA => decimal.TryParse(WHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// NumberOfBetBrainBbookmakers1X2
        /// </summary>
        [ColumnName("Bb1X2")]
        private string? Bb1X2Raw { get; set; }

        public decimal? Bb1X2 => decimal.TryParse(Bb1X2Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumHomeWinOdds
        /// </summary>
        [ColumnName("BbMxH")]
        private string? BbMxHRaw { get; set; }

        public decimal? BbMxH => decimal.TryParse(BbMxHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageHomeWinOdds
        /// </summary>
        [ColumnName("BbAvH")]
        private string? BbAvHRaw { get; set; }

        public decimal? BbAvH => decimal.TryParse(BbAvHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumDrawOdds
        /// </summary>
        [ColumnName("BbMxD")]
        private string? BbMxDRaw { get; set; }

        public decimal? BbMxD => decimal.TryParse(BbMxDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageDrawWinOdds
        /// </summary>
        [ColumnName("BbAvD")]
        private string? BbAvDRaw { get; set; }

        public decimal? BbAvD => decimal.TryParse(BbAvDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumAwayWinOdds
        /// </summary>
        [ColumnName("BbMxA")]
        private string? BbMxARaw { get; set; }

        public decimal? BbMxA => decimal.TryParse(BbMxARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageAwayWinOdds
        /// </summary>
        [ColumnName("BbAvA")]
        private string? BbAvARaw { get; set; }

        public decimal? BbAvA => decimal.TryParse(BbAvARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketMaximumHomeWinOdds
        /// </summary>
        [ColumnName("MaxH")]
        private string? MaxHRaw { get; set; }

        public decimal? MaxH => decimal.TryParse(MaxHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketMaximumDrawWinOdds
        /// </summary>
        [ColumnName("MaxD")]
        private string? MaxDRaw { get; set; }

        public decimal? MaxD => decimal.TryParse(MaxDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketMaximumAwayWinOdds
        /// </summary>
        [ColumnName("MaxA")]
        private string? MaxARaw { get; set; }

        public decimal? MaxA => decimal.TryParse(MaxARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageHomeWinOdds
        /// </summary>
        [ColumnName("AvgH")]
        private string? AvgHRaw { get; set; }

        public decimal? AvgH => decimal.TryParse(AvgHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageDrawWinOdds
        /// </summary>
        [ColumnName("AvgD")]
        private string? AvgDRaw { get; set; }

        public decimal? AvgD => decimal.TryParse(AvgDRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageAwayWinOdds
        /// </summary>
        [ColumnName("AvgA")]
        private string? AvgARaw { get; set; }

        public decimal? AvgA => decimal.TryParse(AvgARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// NumberOfBetBrainBbookmakers2pt5
        /// </summary>
        [ColumnName("BbOU")]
        private string? BbOURaw { get; set; }

        public decimal? BbOU => decimal.TryParse(BbOURaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumOver2Pt5Goals
        /// </summary>
        [ColumnName("BbMx>2.5")]
        private string? BbMxOver2Pt5Raw { get; set; }

        public decimal? BbMxOver2Pt5 => decimal.TryParse(BbMxOver2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageOver2Pt5Goals
        /// </summary>
        [ColumnName("BbAv>2.5")]
        private string? BbAvOver2Pt5Raw { get; set; }

        public decimal? BbAvOver2Pt5 => decimal.TryParse(BbAvOver2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumUnder2Pt5Goals
        /// </summary>
        [ColumnName("BbMx<2.5")]
        private string? BbMxUnder2Pt5Raw { get; set; }

        public decimal? BbMxUnder2Pt5 => decimal.TryParse(BbMxUnder2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageUnder2Pt5Goals
        /// </summary>
        [ColumnName("BbAv<2.5")]
        private string? BbAvUnder2Pt5Raw { get; set; }

        public decimal? BbAvUnder2Pt5 => decimal.TryParse(BbAvUnder2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersOver2Pt5Goals
        /// </summary>
        [ColumnName("GB>2.5")]
        private string? GBOver2Pt5Raw { get; set; }

        public decimal? GBOver2Pt5 => decimal.TryParse(GBOver2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersOver2Pt5Goals
        /// </summary>
        [ColumnName("GB<2.5")]
        private string? GBUnder2Pt5Raw { get; set; }

        public decimal? GBUnder2Pt5 => decimal.TryParse(GBUnder2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365Over2Pt5Goals
        /// </summary>
        [ColumnName("B365>2.5")]
        private string? B365Over2Pt5Raw { get; set; }

        public decimal? B365Over2Pt5 => decimal.TryParse(B365Over2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365Under2Pt5Goals
        /// </summary>
        [ColumnName("B365<2.5")]
        private string? B365Under2Pt5Raw { get; set; }

        public decimal? B365Under2Pt5 => decimal.TryParse(B365Under2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleOver2Pt5Goals
        /// </summary>
        [ColumnName("P>2.5")]
        private string? POver2Pt5Raw { get; set; }

        public decimal? POver2Pt5 => decimal.TryParse(POver2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleUnder2Pt5Goals
        /// </summary>
        [ColumnName("P<2.5")]
        private string? PUnder2Pt5Raw { get; set; }

        public decimal? PinnacleUnder2Pt5Goals => decimal.TryParse(PUnder2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketMaximumOver2Pt5Goals
        /// </summary>
        [ColumnName("Max>2.5")]
        private string? MaxOver2Pt5Raw { get; set; }

        public decimal? MaxOver2Pt5 => decimal.TryParse(MaxOver2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketMaximumUnder2Pt5Goals
        /// </summary>
        [ColumnName("Max<2.5")]
        private string? MaxUnder2Pt5Raw { get; set; }

        public decimal? MaxUnder2Pt5 => decimal.TryParse(MaxUnder2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageOver2Pt5Goals
        /// </summary>
        [ColumnName("Avg>2.5")]
        private string? AvgOver2Pt5Raw { get; set; }

        public decimal? AvgOver2Pt5 => decimal.TryParse(AvgOver2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageUnder2Pt5Goals
        /// </summary>
        [ColumnName("Avg<2.5")]
        private string? AvgUnder2Pt5Raw { get; set; }

        public decimal? AvgUnder2Pt5 => decimal.TryParse(AvgUnder2Pt5Raw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// NumberOfBetBrainBookmakersAsianHandicap
        /// </summary>
        [ColumnName("BbAH")]
        private string? BbAHRaw { get; set; }

        public decimal? BbAH => decimal.TryParse(BbAHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainSizeOfHandicapHome
        /// </summary>
        [ColumnName("BbAHh")]
        private string? BbAHhRaw { get; set; }

        public decimal? BbAHh => decimal.TryParse(BbAHhRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketSizeOfHandicapHome
        /// </summary>
        [ColumnName("AHh")]
        private string? AHhRaw { get; set; }

        public decimal? AHh => decimal.TryParse(AHhRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("BbMxAHH")]
        private string? BbMxAHHRaw { get; set; }

        public decimal? BbMxAHH => decimal.TryParse(BbMxAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("BbAvAHH")]
        private string? BbAvAHHRaw { get; set; }

        public decimal? BbAvAHH => decimal.TryParse(BbAvAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainMaximumAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("BbMxAHA")]
        private string? BbMxAHARaw { get; set; }

        public decimal? BbMxAHA => decimal.TryParse(BbMxAHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// BetbrainAverageAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("BbAvAHA")]
        private string? BbAvAHARaw { get; set; }

        public decimal? BbAvAHA => decimal.TryParse(BbAvAHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("GBAHH")]
        private string? GBAHHRaw { get; set; }

        public decimal? GBAHH => decimal.TryParse(GBAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("GBAHA")]
        private string? GBAHARaw { get; set; }

        public decimal? GBAHA => decimal.TryParse(GBAHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// GamebookersSizeOfHandicapHome
        /// </summary>
        [ColumnName("GBAH")]
        private string? GBAHRaw { get; set; }

        public decimal? GBAH => decimal.TryParse(GBAHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// LadbrokesAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("LBAHH")]
        private string? LBAHHRaw { get; set; }

        public decimal? LBAHH => decimal.TryParse(LBAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// LadbrokesAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("LBAHA")]
        private string? LBAHARaw { get; set; }

        public decimal? LBAHA => decimal.TryParse(LBAHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// LadbrokesAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("LBAH")]
        private string? LBAHRaw { get; set; }

        public decimal? LBAH => decimal.TryParse(LBAHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365AsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("B365AHH")]
        private string? B365AHHRaw { get; set; }

        public decimal? B365AHH => decimal.TryParse(B365AHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365AsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("B365AHA")]
        private string? B365AHARaw { get; set; }

        public decimal? B365AHA => decimal.TryParse(B365AHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// Bet365SizeOfHandicapHome
        /// </summary>
        [ColumnName("B365AH")]
        private string? B365AHRaw { get; set; }

        public decimal? B365AH => decimal.TryParse(B365AHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("PAHH")]
        private string? PAHHRaw { get; set; }

        public decimal? PAHH => decimal.TryParse(PAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("PAHA")]
        private string? PAHARaw { get; set; }

        public decimal? PAHA => decimal.TryParse(PAHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// PinnacleAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("MaxAHH")]
        private string? MaxAHHRaw { get; set; }

        public decimal? MaxAHH => decimal.TryParse(MaxAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketMaximumAsianHandicapAwayTeamOdds
        /// </summary>
        [ColumnName("MaxAHA")]
        private string? MaxAHARaw { get; set; }

        public decimal? MaxAHA => decimal.TryParse(MaxAHARaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("AvgAHH")]
        private string? AvgAHHRaw { get; set; }

        public decimal? AvgAHH => decimal.TryParse(AvgAHHRaw?.Trim(), out var value) ? (decimal?)value : null;

        /// <summary>
        /// MarketAverageAsianHandicapHomeTeamOdds
        /// </summary>
        [ColumnName("AvgAHA")]
        private string? AvgAHARaw { get; set; }

        public decimal? AvgAHA => decimal.TryParse(AvgAHARaw?.Trim(), out var value) ? (decimal?)value : null;

    }
}
