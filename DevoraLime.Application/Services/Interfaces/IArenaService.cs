using DevoraLime.Domain.DomainObjects;

namespace DevoraLime.Application.Services.Interfaces
{
    public interface IArenaService
    {
        Arena GetNewArena(int numberOfHeroes);
        Guid Create(Arena arena);
        Arena? Get(Guid id);
    }
}