using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationGames.Models
{
    [Table("Game")]
    public class Game
    {
        public Game()
        {
            scores = new HashSet<GameScore>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }

        public string GameName { get; set; }

        public virtual ICollection<GameScore> scores { get; set; }

    }
}
