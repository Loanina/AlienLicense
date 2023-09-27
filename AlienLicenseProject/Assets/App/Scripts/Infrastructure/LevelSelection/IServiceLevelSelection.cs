using System;
using App.Scripts.Feature.Models.View.ViewMap;

namespace App.Scripts.Infrastructure.LevelSelection
{
    public interface IServiceLevelSelection
    {
        int CurrentLevelIndex { get; }
        
        ViewMap CurrentLevel { get; }
        event Action OnSelectedLevelChanged;
        void UpdateSelectedLevel(int levelIndex);
    }
}