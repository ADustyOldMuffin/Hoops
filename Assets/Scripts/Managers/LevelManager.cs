using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public delegate void SpawnBallThrownAction();
        public static event SpawnBallThrownAction OnBallThrown;

        public delegate void AddScoreAction(int score);
        public static event AddScoreAction OnAddScore;

        private readonly Dictionary<Level, string> _levels = new Dictionary<Level, string>()
        {
            { Level.MainMenu, "MainMenu" },
            { Level.BeforeTheBuzzer, "BeforeTheBuzzer" }
        };

        private IHoopsLevel _currentLevel;
        private static  Difficulty _currentDifficulty;

        private void Awake()
        {
            Debug.Log("Level Manager awake!");
        }

        public void ChangeLevel(Level level)
        {
            StartCoroutine(LoadScene(_levels[level], _currentDifficulty));
        }

        public static void SpawnBall()
        {
            if (OnBallThrown != null)
                OnBallThrown();
        }

        public static void AddScore(int amount)
        {
            if (OnAddScore != null)
                OnAddScore(amount);
        }

        public void SetLevelsDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 0: 
                    _currentDifficulty = Difficulty.Easy;
                    break;
                case 1:
                    _currentDifficulty = Difficulty.Medium;
                    break;
                case 2:
                    _currentDifficulty = Difficulty.Hard;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(difficulty), "Difficulty level is set to an unknown value.");
            }
        }

        private IEnumerator LoadScene(string sceneName, Difficulty difficulty = Difficulty.Easy)
        {
            var asyncLoadLevel = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            
            while(!asyncLoadLevel.isDone)
                yield return null;

            yield return new WaitForEndOfFrame();

            _currentLevel = GameObject.Find(sceneName).GetComponent<IHoopsLevel>();

            if (_currentLevel == null)
            {
                throw new Exception("Level loaded, but no level interface was found!");
                // TODO maybe handle this more gracefully, like load back to the main menu.
            }
            
            _currentLevel.SetDifficulty(difficulty);
            _currentLevel.InitLevel();
        }
    }
}