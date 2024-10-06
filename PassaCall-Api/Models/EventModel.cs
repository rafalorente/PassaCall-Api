using System.ComponentModel.DataAnnotations;

namespace PassaCall_Api.Models
{
    public class EventModel
    {
        [Key]
        public int IdEvent { get; set; }
        public string? NameEvent { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate{ get; set; }
    }
}
