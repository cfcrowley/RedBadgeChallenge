using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models.Legacy
{
    public class LegacyDetail
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }
        public string DeckStyle { get; set; }
        public double AvgRating { get; set; }
    }
}
