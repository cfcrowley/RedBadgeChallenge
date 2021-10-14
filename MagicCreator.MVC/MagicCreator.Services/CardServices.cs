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
                    CardId = e.CardId,
                    Name = e.Name,
                    Type = e.Type,
                    ManaValue = e.ManaValue,
                    LegacyId = e.LegacyId,
                    ModernId = e.ModernId,
                    CommanderId = e.CommanderId,
                    StandardId = e.StandardId
                });
                return query.ToArray();
            }
        }

        public CardDetail GetCardById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == id);
                return
                    new CardDetail
                    {
                        CardId = entity.CardId,
                        Name = entity.Name,
                        Type = entity.Type,
                        ManaValue = entity.ManaValue,
                        LegacyId = entity.LegacyId,
                        ModernId = entity.ModernId,
                        StandardId = entity.StandardId,
                        CommanderId = entity.StandardId
                    };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == model.CardId);

                entity.Name = model.Name;
                entity.Type = model.Type;
                entity.ManaValue = model.ManaValue;
                entity.LegacyId = model.LegacyId;
                entity.ModernId = model.ModernId;
                entity.CommanderId = model.CommanderId;
                entity.StandardId = model.StandardId; 

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCard(int cardId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == cardId);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
