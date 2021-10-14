using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models
{
    public class CardDetail
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ManaValue { get; set; }
        [ForeignKey(nameof(Modern))]
        public int ModernId { get; set; }
        [ForeignKey(nameof(Legacy))]
        public int LegacyId { get; set; }
        [ForeignKey(nameof(Commander))]
        public int CommanderId { get; set; }
        [ForeignKey(nameof(Standard))]
        public int StandardId { get; set; }
    }
}
