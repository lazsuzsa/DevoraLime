using DevoraLime.Application.Services.Interfaces;
using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.DomainObjects.Interfaces;
using DevoraLime.Domain.Factories;
using DevoraLime.Infrastructure.Repositories.Interfaces;

namespace DevoraLime.Application.Services
{
    public class ArenaService : IArenaService
    {
        private readonly IArenaRepository _arenaRepository;

        public ArenaService(IArenaRepository arenaRepository)
        {
            _arenaRepository = arenaRepository;
        }

        public Guid Create(int numberOfHeroes)
        {
            var arena = new Arena();
            var heroFactory = new RandomHeroFactory();
            arena.Id = Guid.NewGuid();
            for (int i = 0; i < numberOfHeroes; i++)
            {
                IHero newHero = heroFactory.CreateHero();
                newHero.Id = i;
                arena.Heroes.Add(newHero);
            }
            return _arenaRepository.InsertArena(arena);
        }

        public Arena Get(Guid id)
        {
            return _arenaRepository.GetArena(id);
        }

    }
}
