using DevoraLime.Domain.DomainObjects.Interfaces;

namespace DevoraLime.Domain.DomainObjects
{
    public abstract class Hero : IHero
    {
        public int Id { get; set; }
        public abstract string Name { get; }
        public abstract uint MaximumLifePower { get; }
        public uint LifePower { get; set; }
        public bool IsDead => IsKilled || LifePower < (MaximumLifePower / 4);
        public bool IsKilled { get; set; }

        public abstract void Attack(IHero hero);

        public void Rest()
        {
            if (!IsDead)
            {
                LifePower = Math.Min(MaximumLifePower, LifePower + 10);
            }
        }

        public void Fight()
        {
            LifePower /= 2;
        }

        public void BeKilled(IHero hero)
        {
            hero.IsKilled = true;
            hero.LifePower = 0;
        }

        public override string ToString()
        {
            var killedState = IsKilled ? "(Killed)" : "";
            var state = IsDead ? $"Dead{killedState}" : "Alive";
            return $"{Name} [{state};LifePower:{LifePower}]";
        }

    }
}
