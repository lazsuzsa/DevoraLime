using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.DomainObjects.Interfaces;
using DevoraLime.Domain.Factories.Interfaces;

namespace DevoraLime.Domain.Factories
{
    public class RandomHeroFactory : IHeroFactory
    {
        public IHero CreateHero(int id)
        {
            Random rnd = new Random();
            int concreteHeroNumber = rnd.Next(1, 4);
            IHero hero;
            switch (concreteHeroNumber)
            {
                case 1:
                    hero = new Bowman();
                    break;
                case 2:
                    hero = new Rider();
                    break;
                case 3:
                    hero = new Swordsman();
                    break;
                default:
                    hero = new Bowman();
                    break;
            }
            hero.Id = id;
            hero.LifePower = hero.MaximumLifePower;
            return hero;
        }
    }
}
