using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicCreator.Data;

namespace MagicCreator.Services
{
    public class ManaService
    {
        public double CommanderAvg(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                double sum = 0;
                var comValue = ctx.Commanders.Single(c => c.CommanderId == id);
                foreach(Card Card in comValue.Cards)
                {
                    sum += Card.ManaValue;
                }

              
               return comValue.CardCount == 0 ? 0 : sum / comValue.CardCount;



            }
        }
    }
}
