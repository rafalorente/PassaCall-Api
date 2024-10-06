using System.ComponentModel.DataAnnotations;

namespace PassaCall_Api.Models
{
    public class MapModel
    {
        [Key]
        public int IdMap { get; set; }
        public string? MapName { get; set; }
    }
}
