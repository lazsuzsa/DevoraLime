using DevoraLime.Application.Services.Interfaces;
using DevoraLime.Domain.DomainObjects;
using DevoraLime.Domain.DomainObjects.Interfaces;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevoraLime.Application.Services
{
    public class BattleService : IBattleService
    {
        private record Fighters(IHero Attacker, IHero Defender);

        public string PerformBattle(Arena arena)
        {
            if (arena == null) { return ""; }

            int roundCount = 0;
            StringBuilder history = new StringBuilder();
            while (!IsBattleEnded(arena))
            {
                roundCount++;
                history.Append(PerformOneRound(arena, roundCount));
            }
            string result = $"Count of rounds: {roundCount}{Environment.NewLine}{history}"; ;
            return result;
        }

        private StringBuilder PerformOneRound(Arena arena, int roundNumber)
        {
            StringBuilder history = new StringBuilder(); ;

            history.AppendLine($"Round#{roundNumber}");

            var fighters = DrawFighters(arena);
            history.AppendLine($"{fighters.Attacker.Name} attacks {fighters.Defender.Name}");
            var attackerStateBefore = fighters.Attacker.ToString();
            var defenderStateBefore = fighters.Defender.ToString();
            fighters.Attacker.Attack(fighters.Defender);
            history.AppendLine($"{attackerStateBefore} => {fighters.Attacker}");
            history.AppendLine($"{defenderStateBefore} => {fighters.Defender}");

            RestNoFighters(arena, fighters);
            arena.CleanFromDead();
            return history;
        }

        private Fighters DrawFighters(Arena arena)
        {
            Random rnd = new Random();
            var attackerNumber = rnd.Next(0, arena.Heroes.Count);
            var defenderNumber = rnd.Next(0, arena.Heroes.Count - 1);
            if (defenderNumber == attackerNumber)
            {
                defenderNumber++;
                if (defenderNumber == arena.Heroes.Count - 1)
                {
                    defenderNumber = 0;
                }
            }
            return new Fighters(arena.Heroes[attackerNumber], arena.Heroes[defenderNumber]);
        }

        private void RestNoFighters(Arena arena, Fighters fighters)
        {
            foreach (IHero hero in arena.Heroes.Where(x => x != fighters.Attacker && x != fighters.Defender))
            {
                hero.Rest();
            }
        }

        private bool IsBattleEnded(Arena arena)
        {
            return arena?.Heroes == null ? true : arena?.Heroes?.Count <= 1;
        }
    }
}
