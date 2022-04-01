using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplicationGames.Models
{
    public class GameScore
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreID { get; set; }

        [ForeignKey("game")]
        public int GameID { get; set; }

        [ForeignKey("player")]
        public string PlayerID { get; set; }

        public int score { get; set; }

        public virtual Game game { get; set; }
        public virtual ApplicationUser player { get; set; }

    }
}
