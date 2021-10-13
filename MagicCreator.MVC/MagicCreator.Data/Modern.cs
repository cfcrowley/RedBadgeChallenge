using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Data
{
    public class Modern
    {
        [Key]
        public int ModernId { get; set; }
        [Required]
        [Display(Name ="Deck Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Card Count for Deck")]
        public int CardCount { get; set; }
        public string DeckStyle { get; set; }
        [Display(Name ="Average ManaCurve")]
        public double AvgRating { get; set; }
        public virtual List<Card> Cards { get; set; }

    }
}
