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
    }
}
