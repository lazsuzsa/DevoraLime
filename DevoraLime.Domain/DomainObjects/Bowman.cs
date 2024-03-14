using DevoraLime.Domain.DomainObjects.Interfaces;

namespace DevoraLime.Domain.DomainObjects
{
    public class Bowman : Hero
    {
        private const uint SurviveChance = 60;

        public override string Name => $"Bowman#{Id}";

        public override uint MaximumLifePower => 100;

        public override void Attack(IHero defender)
        {
            if (defender is Rider)
            {
                if (!RandomSurvived(SurviveChance)) { BeKilled(defender); }
            }
            if (defender is Swordsman) { BeKilled(defender); }
            if (defender is Bowman) { BeKilled(defender); }

            Fight();
            defender.Fight();
        }

        private bool RandomSurvived(uint surviveChance)
        {
            if (surviveChance == 0) { return false; }
            if (surviveChance >= 100) { return true; }

            Random rnd = new Random();
            int number = rnd.Next(1, 100);

            return number <= surviveChance;
        }
    }
}
