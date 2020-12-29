using System;
using System.Collections;
using Constants;
using Lean.Transition;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class MainMenu : MonoBehaviour, IHoopsLevel
    {
        public Level LevelType { get; } = Level.MainMenu;
        public MonoBehaviour Behaviour { get; private set; }

        [SerializeField] private RectTransform mainFrame;
        [SerializeField] private RectTransform levelsFrame;
        [SerializeField] private Image background;


        private void Awake()
        {
            Behaviour = this;
            StartCoroutine(FindObjectOfType<AudioManager>().PlayMusic(HoopsMusic.MainBackground, true));
        }

        public IEnumerator SpawnBall()
        {
            yield return null;
        }

        public void SetDifficulty(Difficulty difficulty)
        {
        }

        public void InitLevel()
        {
            background.colorTransition(new Color(0, 0, 0, 0), 2f, LeanEase.Smooth);
            mainFrame.gameObject.SetActive(true);
            mainFrame.GetComponent<CanvasGroup>().alphaTransition(1f, 2f, LeanEase.Smooth);
        }

        public void StartGame()
        {
        }

        public void StopGame()
        {
        }

        public void OnLevelsButtonPress()
        {
            mainFrame.GetComponent<CanvasGroup>().alphaTransition(0f, 0.5f);
            mainFrame.gameObject.SetActive(false);
            levelsFrame.gameObject.SetActive(true);
            levelsFrame.GetComponent<CanvasGroup>().alphaTransition(1f, 0.5f);
        }

        public void OnBackLevelButtonPress()
        {
            levelsFrame.GetComponent<CanvasGroup>().alphaTransition(0f, 0.5f);
            levelsFrame.gameObject.SetActive(false);
            mainFrame.gameObject.SetActive(true);
            mainFrame.GetComponent<CanvasGroup>().alphaTransition(1f, 0.5f);
        }

        public void OnBeforeTheBuzzerButtonPress()
        {
            FindObjectOfType<LevelManager>().ChangeLevel(Level.BeforeTheBuzzer);
        }
    }
}