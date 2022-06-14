using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISaveProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : ISaveProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}