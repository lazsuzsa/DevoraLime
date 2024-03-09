using DevoraLime.Domain.DomainObjects;

namespace DevoraLime.Infrastructure.Repositories.Interfaces
{
    public interface IArenaRepository
    {
        Guid InsertArena(Arena arena);
        Arena? GetArena(Guid id);
    }
}
