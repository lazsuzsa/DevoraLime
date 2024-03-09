using DevoraLime.Domain.DomainObjects.Interfaces;

namespace DevoraLime.Domain.DomainObjects
{
    public class Swordsman : Hero
    {
        public override string Name => $"Swordsman#{Id}";

        public override uint MaximumLifePower => 120;

        public override void Attack(IHero defender)
        {
            if (defender is Rider) { }
            if (defender is Swordsman) { Kill(defender); }
            if (defender is Bowman) { Kill(defender); }

            Fight();
            defender.Fight();
        }
    }
}
