using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Data
{
    public class LegacyGame
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        [Display(Name = "Your Deck ID")]
        public int DeckId { get; set; }
        [Required]
        [Display(Name = "Enemy Deck ID")]
        public int EnemyID { get; set; }
        public string Result { get; set; }
        public virtual Legacy Legacy { get; set; }
    }
}
