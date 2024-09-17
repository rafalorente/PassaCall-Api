namespace PassaCall_Api.Models
{
    public class TeamModel
    {
        //direitinha [JsonIgnore] - não aparece no swagger
        public int IdTeam { get; set; }
        public string NameTeam { get; set; }

    }
}
