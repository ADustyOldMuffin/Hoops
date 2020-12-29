using Constants;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public MasterInput Input { get; private set; }

        private LevelManager _levelManager = null;

        private void Awake()
        {
            Input = new MasterInput();
            _levelManager = FindObjectOfType<LevelManager>();
            
            if(_levelManager != null)
                _levelManager.ChangeLevel(Level.MainMenu);
        }
    }
}