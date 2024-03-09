using DevoraLime.Domain.DomainObjects.Interfaces;

namespace DevoraLime.Objects
{
    public abstract class Hero : IHero
    {
        public int Id { get; set; }
        public abstract string Name { get; }
        public abstract uint MaximumLifePower { get; }
        public uint LifePower { get; set; }
        public bool IsDead => IsKilled || LifePower < (MaximumLifePower / 4);
        public bool IsKilled { get; set; }

        public Hero() 
        {
            LifePower = MaximumLifePower;
        }
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

        public void Kill(IHero hero)
        {
            if (hero != null)
            {
                hero.IsKilled = true;
            }
        }

        public override string ToString()
        {
            string state = IsDead ? "Dead" : "Alive"; 
            return $"{Name} [{state};LifePower:{LifePower}]";
        }

    }
}
