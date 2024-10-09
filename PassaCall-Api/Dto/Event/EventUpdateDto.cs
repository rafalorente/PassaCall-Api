namespace PassaCall_Api.Dto.Event
{
    public class EventUpdateDto
    {
        public int IdEvent { get; set; }
        public string? NameEvent { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
    }
}
