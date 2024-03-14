namespace DevoraLime.Domain.DomainObjects.Interfaces
{
    public interface IHero
    {
        uint MaximumLifePower { get; }

        int Id { get; set; }

        string Name { get; }

        uint LifePower { get; set; }

        bool IsDead { get; }

        bool IsKilled { get; set; }

        void Rest();

        void Fight();

        void Attack(IHero hero);

        void BeKilled(IHero hero);
    }
}
