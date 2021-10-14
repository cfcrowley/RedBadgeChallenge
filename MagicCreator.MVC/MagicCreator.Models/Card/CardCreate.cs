using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models
{
    public class CardCreate
    {
        [Required]
        [Display(Name ="Card Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Card Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name ="Mana Value of Card")]
        public int ManaValue { get; set; }
        public int LegacyId { get; set; }
        public int ModernId { get; set; }
        public int CommanderId { get; set; }
        public int StandardId { get; set; }
    }
}
