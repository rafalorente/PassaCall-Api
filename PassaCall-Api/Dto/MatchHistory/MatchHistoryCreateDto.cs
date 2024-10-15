namespace PassaCall_Api.Dto.MatchHistory
{
    public class MatchHistoryCreateDto
    {
        public required string Team { get; set; }
        public required string Map { get; set; }
        public int WinTwoRounds { get; set; }
        public int WinRoundPistolCt { get; set; }
        public int WinRoundPistolTr { get; set; }
        public int CtHalf { get; set; }
        public int TrHalf { get; set; }
        public int OverTime { get; set; }
        public DateTime MatchDate { get; set; }
        public required string Event { get; set; }
        public int MapPick { get; set; }
    }
}
