using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISaveProgressReader> ProgressReaders { get; } = new List<ISaveProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) =>
            InstantiateRegistered(AssetPaht.HeroPath, at.transform.position);

        public void CreateHud() =>
            InstantiateRegistered(AssetPaht.HudPath);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject game = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(game);
            return game;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject game = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(game);
            return game;
        }

        private void RegisterProgressWatchers(GameObject game)
        {
            foreach (ISaveProgressReader progressReader in game.GetComponentsInChildren<ISaveProgressReader>())
                Register(progressReader);
        }

        private void Register(ISaveProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}