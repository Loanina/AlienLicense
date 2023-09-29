using System;
using App.Scripts.Feature.Models.View.ViewMap;

namespace App.Scripts.Infrastructure.LevelSelection
{
    public class ServiceLevelSelection : IServiceLevelSelection
    {
        private readonly ConfigLevelSelection _configLevelSelection;

        private int _currentLevelIndex;
        
        public ViewMap CurrentLevel => _configLevelSelection.Levels[_currentLevelIndex-1];

        public ServiceLevelSelection(ConfigLevelSelection configLevelSelection)
        {
            _configLevelSelection = configLevelSelection;
            CurrentLevelIndex = configLevelSelection.InitLevelIndex;
        }

        public int CurrentLevelIndex
        {
            get => _currentLevelIndex;
            private set
            {
                _currentLevelIndex = value;
                OnSelectedLevelChanged?.Invoke();
            }
        }

        

        public event Action OnSelectedLevelChanged;

        public void UpdateSelectedLevel(int levelIndex)
        {
            if (levelIndex > _configLevelSelection.Levels.Count)
            {
                CurrentLevelIndex = 1;
                return;
            }

            if (levelIndex <= 0)
            {
                CurrentLevelIndex = _configLevelSelection.Levels.Count;
                return;
            }

            CurrentLevelIndex = levelIndex;
            
        }
    }
}