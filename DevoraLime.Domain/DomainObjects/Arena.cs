using DevoraLime.Domain.DomainObjects.Interfaces;

namespace DevoraLime.Domain.DomainObjects
{
    public class Arena
    {
        public Guid Id { get; set; }
        public IList<IHero> Heroes { get; set; } = new List<IHero>();

        public void CleanFromDead()
        {
            var deadHeroes = Heroes.Where(hero => hero.IsDead).ToList();
            deadHeroes.ForEach(hero => Heroes.Remove(hero));
        }
    }
}
