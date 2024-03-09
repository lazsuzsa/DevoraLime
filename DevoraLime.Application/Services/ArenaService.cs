using DevoraLime.Application.Services.Interfaces;
using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.DomainObjects.Interfaces;
using DevoraLime.Domain.Factories.Interfaces;
using DevoraLime.Infrastructure.Repositories.Interfaces;

namespace DevoraLime.Application.Services
{
    public class ArenaService : IArenaService
    {
        private readonly IArenaRepository _arenaRepository;
        private readonly IHeroFactory _heroFactory;

        public ArenaService(IArenaRepository arenaRepository, IHeroFactory heroFactory)
        {
            _arenaRepository = arenaRepository;
            _heroFactory = heroFactory;
        }

        public Arena GetNewArena(int numberOfHeroes)
        {
            var arena = new Arena
            {
                Id = Guid.NewGuid(),
                Heroes = new List<IHero>()
            };

            for (int i = 0; i < numberOfHeroes; i++)
            {
                IHero newHero = _heroFactory.CreateHero();
                newHero.Id = i;
                arena.Heroes.Add(newHero);
            }

            return arena;
        }

        public Guid Create(Arena arena)
        {
            var arenaId = _arenaRepository.InsertArena(arena);
            return arenaId;
        }

        public Arena? Get(Guid id)
        {
            return _arenaRepository.GetArena(id);
        }

    }
}
