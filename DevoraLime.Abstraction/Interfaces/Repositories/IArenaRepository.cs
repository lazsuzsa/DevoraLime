using DevoraLime.Domain.DomainObjects;

namespace DevoraLime.Abstraction.Interfaces.Repositories
{
    public interface IArenaRepository
    {
        Guid InsertArena(Arena arena);
        Arena? GetArena(Guid id);
    }
}
