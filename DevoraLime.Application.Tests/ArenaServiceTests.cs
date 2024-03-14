using DevoraLime.Abstraction.Interfaces.Repositories;
using DevoraLime.Application.Services;
using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.Factories.Interfaces;
using Moq;
using Shouldly;

namespace DevoraLime.Application.Tests
{
    [TestClass]
    public class ArenaServiceTests
    {
        [TestMethod]
        public void GetNewArenaTest()
        {
            var mockArenaRepository = new Mock<IArenaRepository>();

            var mockHeroFactory = new Mock<IHeroFactory>();
            mockHeroFactory.Setup(x => x.CreateHero(It.IsAny<int>())).Returns(new Rider());

            var arenaService = new ArenaService(mockArenaRepository.Object, mockHeroFactory.Object);
            var arena = arenaService.GetNewArena(100);

            arena.Heroes.Count.ShouldBe(100);
            arena.Id.ShouldNotBe(Guid.Empty);
        }

        [TestMethod]
        public void CreateTest()
        {
            var mockArenaRepository = new Mock<IArenaRepository>();

            var mockHeroFactory = new Mock<IHeroFactory>();
            mockHeroFactory.Setup(x => x.CreateHero(It.IsAny<int>())).Returns(new Rider());

            var arenaService = new ArenaService(mockArenaRepository.Object, mockHeroFactory.Object);
            var arena = arenaService.GetNewArena(100);
            mockArenaRepository.Setup(x => x.InsertArena(arena)).Returns(arena.Id);

            var arenaId = arenaService.Create(arena);

            mockArenaRepository.Verify(x=>x.InsertArena(arena), Times.Once);
            arenaId.ShouldBe(arena.Id);
        }

        [TestMethod]
        public void GetTest_PositivCase()
        {
            var mockArenaRepository = new Mock<IArenaRepository>();

            var mockHeroFactory = new Mock<IHeroFactory>();
            mockHeroFactory.Setup(x => x.CreateHero(It.IsAny<int>())).Returns(new Rider());

            var arenaService = new ArenaService(mockArenaRepository.Object, mockHeroFactory.Object);
            var mockArena = new Arena();
            mockArena.Id = Guid.NewGuid();
            mockArenaRepository.Setup(x => x.GetArena(mockArena.Id)).Returns(mockArena);

            var arena = arenaService.Get(mockArena.Id);

            mockArenaRepository.Verify(x => x.GetArena(mockArena.Id), Times.Once);
            arena.Id.ShouldBe(mockArena.Id);
        }
        
        [TestMethod]
        public void GetTest_NegativCase()
        {
            var mockArenaRepository = new Mock<IArenaRepository>();

            var mockHeroFactory = new Mock<IHeroFactory>();
            mockHeroFactory.Setup(x => x.CreateHero(It.IsAny<int>())).Returns(new Rider());

            var arenaService = new ArenaService(mockArenaRepository.Object, mockHeroFactory.Object);
            var mockArena = new Arena();
            mockArena.Id = Guid.NewGuid();
            mockArenaRepository.Setup(x => x.GetArena(mockArena.Id)).Returns(mockArena);

            var arena = arenaService.Get(Guid.NewGuid());

            mockArenaRepository.Verify(x => x.GetArena(It.IsAny<Guid>()), Times.Once);
            arena.ShouldBeNull();
        }

    }
}
