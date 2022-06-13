﻿using CodeBase.Cameralogic;
using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    internal class LevelLoadState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LevelLoadState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));

            _gameFactory.CreateHud();

            CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject hero) =>
            Camera.main
            .GetComponent<CameraFollow>()
            .Follow(hero);
    }
}