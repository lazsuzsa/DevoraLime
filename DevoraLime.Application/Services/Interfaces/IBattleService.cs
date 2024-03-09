using DevoraLime.Domain.DomainObjects;

namespace DevoraLime.Application.Services.Interfaces
{
    public interface IBattleService
    {
        string PerformBattle(Arena arena);
    }
}