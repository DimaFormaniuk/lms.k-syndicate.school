using CodeBase.Data;
using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}