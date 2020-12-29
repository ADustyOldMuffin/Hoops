using System.Collections;
using Constants;
using UnityEngine;

namespace Levels
{
    public interface IHoopsLevel
    {
        Level LevelType { get; }

        MonoBehaviour Behaviour { get; }

        void SetDifficulty(Difficulty difficulty);

        void InitLevel();

        void StartGame();

        void StopGame();
    }
}