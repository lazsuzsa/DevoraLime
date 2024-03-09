using DevoraLime.Application.Services;
using DevoraLime.Application.Services.Interfaces;
using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.DomainObjects.Interfaces;
using DevoraLime.Domain.Factories;
using Moq;

namespace DevoraLime.Application.Tests
{
    [TestClass]
    public class BattleServiceTests
    {
        [TestMethod]
        public void PerformBattleTest()
        {
            var arena = CreateArena(100);

            BattleService battleService = new BattleService();

            var history = battleService.PerformBattle(arena);
        }


        private Arena CreateArena(uint numberOfHeroes)
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
            return arena;
        }
    }
}