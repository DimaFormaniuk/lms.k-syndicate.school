using UnityEngine;

namespace CodeBase.Services
{
    public interface IInputService
    {
        public Vector2 Axis { get; }
        public bool IsAttackButtonUp { get; }
    }
}

