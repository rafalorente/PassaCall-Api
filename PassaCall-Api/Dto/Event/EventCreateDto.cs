namespace PassaCall_Api.Dto.Event
{
    public class EventCreateDto
    {
        public string? NameEvent { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
