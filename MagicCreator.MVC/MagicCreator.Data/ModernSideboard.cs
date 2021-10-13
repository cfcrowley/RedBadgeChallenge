using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(Modern))]
        public int ModernId { get; set; }
        [Required]
        [Range(0,15)]
        [Display(Name ="Number of Cards in Sideboard")]
        public int CardCount { get; set; }
        public virtual List<Card> Cards { get; set; }
        public virtual Modern Modern { get; set; }
        

    }
}
