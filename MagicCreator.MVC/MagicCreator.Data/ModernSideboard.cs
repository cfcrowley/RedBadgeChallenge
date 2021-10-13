using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Data
{
    public class ModernSideboard
    {
        [Key]
        public int SideId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Modern Deck Id")]
        public int ModernId { get; set; }
        [Required]
        [Range(0,15)]
        [Display(Name ="Number of Cards in Sideboard")]
        public int CardCount { get; set; }
        public virtual List<Card> Cards { get; set; }
        

    }
}
