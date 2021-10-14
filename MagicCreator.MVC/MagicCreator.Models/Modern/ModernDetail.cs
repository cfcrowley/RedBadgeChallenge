using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models.Modern
{
    public class ModernDetail
    {
        public int ModernId { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }
        public string DeckStyle { get; set; }
        public double AvgRating { get; set; }
    }
}
