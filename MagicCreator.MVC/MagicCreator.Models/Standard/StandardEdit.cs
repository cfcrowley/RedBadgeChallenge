using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models.Standard
{
    public class StandardEdit
    {
        public int StandardId { get; set; }
        public string Name { get; set; }
        public int CardCount { get; set; }
        public string DeckStyle { get; set; }
    }
}

