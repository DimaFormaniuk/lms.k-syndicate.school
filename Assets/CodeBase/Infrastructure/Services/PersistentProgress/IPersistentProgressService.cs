using CodeBase.Data;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}