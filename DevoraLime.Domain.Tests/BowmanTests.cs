using DevoraLime.Domain.DomainObjects;
using Shouldly;

namespace DevoraLime.Domain.Tests
{
    [TestClass]
    public class BowmanTests : HeroTests<Bowman>
    {
        [TestMethod]
        public void SwordsManShouldBeKilledOnAttack()
        {
            var bowman = new Bowman();
            var swordsman = new Swordsman();
            
            bowman.Attack(swordsman);

            bowman.IsKilled.ShouldBeFalse();
            swordsman.IsKilled.ShouldBeTrue();
        }

        [TestMethod]
        public void DefenderBowmanManShouldBeKilledOnAttack()
        {
            var bowman = new Bowman();
            var defenderBowman = new Bowman();

            bowman.Attack(defenderBowman);

            bowman.IsKilled.ShouldBeFalse();
            defenderBowman.IsKilled.ShouldBeTrue();
        }
    }
}
