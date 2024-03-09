using DevoraLime.Domain.DomainObjects;
using Shouldly;

namespace DevoraLime.Domain.Tests
{
    [TestClass]
    public class SwordsmanTests : HeroTests<Swordsman>
    {
        [TestMethod]
        public void RiderShouldNotBeKilledOnAttack()
        {
            var swordsman = new Swordsman();
            var rider = new Rider();

            swordsman.Attack(rider);

            swordsman.IsKilled.ShouldBeFalse();
            rider.IsKilled.ShouldBeFalse();
        }

        [TestMethod]
        public void SwordsManShouldBeKilledOnAttack()
        {
            var swordsman = new Swordsman();
            var defenderSwordsman = new Swordsman();

            swordsman.Attack(defenderSwordsman);

            swordsman.IsKilled.ShouldBeFalse();
            defenderSwordsman.IsKilled.ShouldBeTrue();
        }

        [TestMethod]
        public void BowmanManShouldBeKilledOnAttack()
        {
            var swordsman = new Swordsman();
            var bowman = new Bowman();

            swordsman.Attack(bowman);

            swordsman.IsKilled.ShouldBeFalse();
            bowman.IsKilled.ShouldBeTrue();
        }

        [TestMethod]
        public void NameTest()
        {
            var swordsman = new Swordsman { Id = 100 };
            swordsman.Name.ShouldBe($"Swordsman#{swordsman.Id}");
        }
    }
}