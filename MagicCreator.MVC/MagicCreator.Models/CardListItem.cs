using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models
{
    public class CardListItem
    {
        public int CardId { get; set; }
        [Display(Name ="Card Name")]
        public string Name { get; set; }
        [Display(Name ="Card Type")]
        public string Type { get; set; }
    }
}
