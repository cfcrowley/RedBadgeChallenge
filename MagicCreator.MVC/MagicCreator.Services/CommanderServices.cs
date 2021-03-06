using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicCreator.Data;
using MagicCreator.Models.Commander;

namespace MagicCreator.Services
{
    public class CommanderServices
    {
        public CommanderServices() { }

        public bool CreateCommander(CommanderCreate model)
        {
            var entity = new Commander()
            {
                Name = model.Name,
                CardCount = model.CardCount,
                General = model.General,
                DeckStyle = model.DeckStyle,
                AvgRating = 0
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Commanders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommanderListItem> GetCommanders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Commanders.Select(e => new CommanderListItem
                {
                    CommanderId = e.CommanderId,
                    Name = e.Name,
                    CardCount = e.CardCount,
                    General = e.General,
                    DeckStyle = e.DeckStyle,
                    AvgRating = new ManaService().CommanderAvg(e.CommanderId)
                });
                return query.ToArray();
            }
        }

        public CommanderDetail GetCommanderById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Commanders.Single(e => e.CommanderId == id);
                return
                    new CommanderDetail
                    {
                        CommanderId = entity.CommanderId,
                        Name = entity.Name,
                        CardCount = entity.CardCount,
                        General = entity.General,
                        DeckStyle = entity.DeckStyle,
                        AvgRating = new ManaService().CommanderAvg(entity.CommanderId)
                    };
            }
        }

        public bool UpdateCommander(CommanderEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Commanders.Single(e => e.CommanderId == model.CommanderId);

                entity.Name = model.Name;
                entity.CardCount = model.CardCount;
                entity.General = model.General;
                entity.DeckStyle = model.DeckStyle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCommander(int comId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Commanders.Single(e => e.CommanderId == comId);

                ctx.Commanders.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
