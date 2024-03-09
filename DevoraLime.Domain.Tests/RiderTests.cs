using DevoraLime.Domain.DomainObjects;
using Shouldly;

namespace DevoraLime.Domain.Tests
{
    [TestClass]
    public class RiderTests : HeroTests<Rider>
    {
        [TestMethod]
        public void DefenderRiderManShouldBeKilledOnAttack()
        {
            var rider = new Rider();
            var defenderRider = new Rider();

            rider.Attack(defenderRider);

            rider.IsKilled.ShouldBeFalse();
            defenderRider.IsKilled.ShouldBeTrue();
        }

        [TestMethod]
        public void SwordsManShouldBeKilledOnAttack()
        {
            var rider = new Rider();
            var swordsman = new Swordsman();

            rider.Attack(swordsman);

            rider.IsKilled.ShouldBeTrue();
            swordsman.IsKilled.ShouldBeFalse();
        }

        [TestMethod]
        public void BowmanManShouldBeKilledOnAttack()
        {
            var rider = new Rider();
            var bowman = new Bowman();

            rider.Attack(bowman);

            rider.IsKilled.ShouldBeFalse();
            bowman.IsKilled.ShouldBeTrue();
        }
    }
}
