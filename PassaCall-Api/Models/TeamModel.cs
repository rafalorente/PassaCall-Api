using System.ComponentModel.DataAnnotations;

namespace PassaCall_Api.Models
{
    public class TeamModel
    {
        //direitinha [JsonIgnore] - não aparece no swagger
        [Key]
        public int IdTeam { get; set; }
        public string? NameTeam { get; set; }

    }
}
