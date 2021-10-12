using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Data
{
    public class Legacy
    {
        [Key]
        public int LegacyId { get; set; }
        [Required]
        [Display(Name = "Deck Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Card Count for Deck")]
        public int CardCount { get; set; }
        public string DeckStyle { get; set; }
        public virtual List<Card> Cards { get; set; }

    }
}
