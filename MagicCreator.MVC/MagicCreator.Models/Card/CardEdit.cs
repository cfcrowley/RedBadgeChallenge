using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models
{
    public class CardEdit
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ManaValue { get; set; }
        public int LegacyId { get; set; }
        public int ModernId { get; set; }
        public int CommanderId { get; set; }
        public int StandardId { get; set; }
    }
}
