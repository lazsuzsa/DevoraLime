using DevoraLime.Domain.DomainObjects;

namespace DevoraLime.Application.Services.Interfaces
{
    public interface IArenaService
    {
        Guid Create(int numberOfHeroes);
        Arena Get(Guid id);
    }
}