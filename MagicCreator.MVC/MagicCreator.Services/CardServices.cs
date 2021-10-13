using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicCreator.Data;
using MagicCreator.Models;

namespace MagicCreator.Services
{
    public class CardServices
    {
        public CardServices() { }
        public bool CreateCard(CardCreate model)
        {
            var entity = new Card()
            {
                Name = model.Name,
                Type = model.Type,
                ManaValue = model.ManaValue
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CardListItem> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Cards.Select(e => new CardListItem
                {
                    Name = e.Name,
                    Type = e.Type,
                    ManaValue = e.ManaValue
                });
                return query.ToArray();
            }
        }
    }
}
