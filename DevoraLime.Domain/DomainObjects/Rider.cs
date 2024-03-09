using DevoraLime.Domain.DomainObjects.Interfaces;

namespace DevoraLime.Domain.DomainObjects
{
    public class Rider : Hero
    {
        public override string Name => $"Rider#{Id}";

        public override uint MaximumLifePower => 150;

        public override void Attack(IHero defender)
        {
            if (defender is Rider) { Kill(defender); }
            if (defender is Swordsman) { defender.Kill(this); }
            if (defender is Bowman) { Kill(defender); }

            Fight();
            defender.Fight();
        }
    }
}
