using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISaveProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject CreateHero(GameObject at);
        void CreateHud();
        void Cleanup();
    }
}