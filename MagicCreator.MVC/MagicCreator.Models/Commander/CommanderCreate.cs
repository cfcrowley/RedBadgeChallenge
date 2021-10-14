﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCreator.Models.Commander
{
    public class CommanderCreate
    {
        public string Name { get; set; }
        public int CardCount { get; set; }
        public string General { get; set; }
        public string DeckStyle { get; set; }
    }
}
