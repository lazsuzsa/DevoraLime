using DevoraLime.Domain.DomainObjects.Interfaces;
using Shouldly;

namespace DevoraLime.Domain.Tests
{
    [TestClass]
    public abstract class HeroTests<T> where T : IHero, new()
    {

        [TestMethod]
        public void HeroShouldBeDead_KilledCase() 
        {
            var hero = new T();
            hero.IsKilled = true;
            hero.LifePower = hero.MaximumLifePower;

            hero.IsDead.ShouldBeTrue();
        }

        [TestMethod]
        public void HeroShouldBeDead_TooLowLifePowerCase()
        {
            var hero = new T();
            hero.IsKilled = false;
            hero.LifePower = hero.MaximumLifePower / 4 - 1;

            hero.IsDead.ShouldBeTrue();
        }

        [TestMethod]
        public void HeroShouldBeDead_KilledAndTooLowLifePowerCase()
        {
            var hero = new T();
            hero.LifePower = hero.MaximumLifePower / 4 - 1;
            hero.IsKilled = true;

            hero.IsDead.ShouldBeTrue();
        }

        [TestMethod]
        public void HeroShouldNotBeDead_NotKilledAndEnoughLifePowerCase()
        {
            var hero = new T();
            hero.LifePower = hero.MaximumLifePower / 4 + 1;
            hero.IsKilled = false;

            hero.IsDead.ShouldBeFalse();
        }

        [TestMethod]
        public void RestShouldIncreaseLifePower_LowLifePowerCase()
        {
            var hero = new T();
            var initialLifePower = hero.MaximumLifePower - 15;
            hero.LifePower = initialLifePower;

            hero.Rest();
            hero.LifePower.ShouldBe(initialLifePower + 10);
        }

        [TestMethod]
        public void RestShouldNotIncreaseLifePower_MaxLifePowerCase()
        {
            var hero = new T();
            uint initialLifePower = hero.MaximumLifePower - 5;
            hero.LifePower = initialLifePower;

            hero.Rest();
            hero.LifePower.ShouldBe(hero.MaximumLifePower);
        }

        [TestMethod]
        public void FightShouldHalfTheLifePower()
        {
            var hero = new T();
            uint initialLifePower = 13;
            hero.LifePower = initialLifePower;

            hero.Fight();
            hero.LifePower.ShouldBe<uint>(6);

            hero.Fight();
            hero.LifePower.ShouldBe<uint>(3);
        }
    }
}