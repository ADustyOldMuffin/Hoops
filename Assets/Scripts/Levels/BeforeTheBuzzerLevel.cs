using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using Lean.Gui;
using Managers;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    public class BeforeTheBuzzerLevel : MonoBehaviour, IHoopsLevel
    {
        public Level LevelType { get; protected set; } = Level.BeforeTheBuzzer;
        public MonoBehaviour Behaviour { get; private set; }
        
        [Header("Locations")]
        [SerializeField] private List<Transform> easyLocations;
        [SerializeField] private List<Transform> mediumLocations;
        [SerializeField] private List<Transform> hardLocations;
        [SerializeField] private List<Transform> easyCameraLocations;
        [SerializeField] private List<Transform> mediumCameraLocations;
        [SerializeField] private List<Transform> hardCameraLocations;
        
        [Header("Game Settings")]
        [SerializeField] private GameObject ball;
        [SerializeField] private float levelTime = 30.0f;
        
        [Header("GUI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        
        [Header("Camera Settings")]
        [SerializeField] private Transform cameraLocation;

        [Header("Misc")]
        [SerializeField] private Transform ballTarget;
        [SerializeField] private LeanWindow finishedModal;

        private Difficulty _currentDifficulty = Difficulty.Easy;
        private AudioManager _audioManager;
        private LevelManager _levelManager;
        private Transform _currentLocation;
        private float _currentTime = 0.0f;
        private int _currentScore = 0;
        private bool _isRunning = false;
        private int _bestScore = 0;

        private void Awake()
        {
            Behaviour = this;
            _audioManager = FindObjectOfType<AudioManager>();
            _levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnEnable()
        {
            LevelManager.OnBallThrown += OnBallThrownEvent;
            LevelManager.OnAddScore += OnScoreAddEvent;
        }

        private void OnDisable()
        {
            LevelManager.OnBallThrown -= OnBallThrownEvent;
            LevelManager.OnAddScore -= OnScoreAddEvent;
        }

        private void Update()
        {
            if (_isRunning)
                timeText.text = GetFormattedTime();
        }

        private void FixedUpdate()
        {
            if (!_isRunning)
                return;

            _currentTime += Time.fixedDeltaTime;

            if (_currentTime > levelTime)
                StopGame();
        }

        private IEnumerator SpawnBall(int wait = 0)
        {
            yield return new WaitForSeconds(1);
            var go = Instantiate(ball, _currentLocation.position, Quaternion.identity);
            go.transform.LookAt(ballTarget);
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            _currentDifficulty = difficulty;
        }

        public void InitLevel()
        {
            StartGame();
        }

        public void StartGame()
        {
            SetLocation();
            finishedModal.TurnOff();
            var go = Instantiate(ball, _currentLocation.position, Quaternion.identity);
            go.transform.LookAt(ballTarget);
            _isRunning = true;
        }

        public void StopGame()
        {
            _isRunning = false;
            
            var objects = FindObjectsOfType<BallInteraction>();

            foreach (var ballInteraction in objects)
            {
                Destroy(ballInteraction.gameObject);
            }

            StartCoroutine(_audioManager.PlayClipAtPoint(cameraLocation.position, HoopsAudioClip.Buzzer));

            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
                bestScoreText.text = _bestScore.ToString();
            }

            finalScoreText.text = _currentScore.ToString();
            finishedModal.TurnOn();

            _currentScore = 0;
            scoreText.text = _currentScore.ToString();
            _currentTime = 0.0f;
            timeText.text = GetFormattedTime();
            
        }

        private void SetLocation()
        {
            List<Transform> locations;
            List<Transform> cameraLocations;

            switch (_currentDifficulty)
            {
                case Difficulty.Easy:
                    locations = easyLocations;
                    cameraLocations = easyCameraLocations;
                    break;
                case Difficulty.Medium:
                    locations = mediumLocations;
                    cameraLocations = mediumCameraLocations;
                    break;
                case Difficulty.Hard:
                    locations = hardLocations;
                    cameraLocations = hardCameraLocations;
                    break;
                default:
                    throw new Exception("Difficulty is not a valid value.");
            }
            
            var selection = Random.Range(0, locations.Count);
            _currentLocation = locations[selection];
            cameraLocation.position = cameraLocations[selection].position;
        }

        private string GetFormattedTime()
        {
            return _currentTime.ToString("0.0");
        }

        private void OnBallThrownEvent()
        {
            if(_isRunning)
                StartCoroutine(SpawnBall(1));
        }

        private void OnScoreAddEvent(int amount)
        {
            _currentScore += amount;
            scoreText.text = _currentScore.ToString();
        }

        public void OnMainMenuClick()
        {
            _levelManager.ChangeLevel(Level.MainMenu);
        }
    }
}