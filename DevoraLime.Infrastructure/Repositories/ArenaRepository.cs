using DevoraLime.Domain.DomainObjects;
using DevoraLime.Infrastructure.Repositories.Interfaces;
using LiteDB;

namespace DevoraLime.Infrastructure.Repositories
{
    public class ArenaRepository : IArenaRepository
    {
        private const string DBNAME = "devoralime.db";
        public Arena GetArena(Guid id)
        {
            using (var db = new LiteDatabase(DBNAME))
            {
                var collection = db.GetCollection<Arena>("arena");
                var arena = collection.FindOne(x => x.Id == id);
                return arena;
            }
        }

        public Guid InsertArena(Arena arena)
        {
            using (var db = new LiteDatabase(DBNAME))
            {
                var collection = db.GetCollection<Arena>("arena");
                if (arena.Id == Guid.Empty)
                {
                    arena.Id = Guid.NewGuid();
                }
                collection.Insert(arena);
                collection.EnsureIndex(x => x.Id);
                return arena.Id;
            }
        }
    }
}
