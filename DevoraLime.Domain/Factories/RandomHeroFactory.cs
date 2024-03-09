using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.DomainObjects.Interfaces;
using DevoraLime.Domain.Factories.Interfaces;

namespace DevoraLime.Domain.Factories
{
    public class RandomHeroFactory : IHeroFactory
    {
        public IHero CreateHero()
        {
            Random rnd = new Random();
            int concreteHeroNumber = rnd.Next(1, 4);
            switch (concreteHeroNumber)
            {
                case 1:
                    return new Bowman();
                case 2:
                    return new Rider();
                case 3:
                    return new Swordsman();
                default:
                    return new Bowman();
            }
        }
    }
}
