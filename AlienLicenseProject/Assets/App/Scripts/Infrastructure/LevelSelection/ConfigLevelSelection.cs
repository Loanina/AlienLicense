using System;
using System.Collections.Generic;
using App.Scripts.Feature.Models.View.ViewMap;

namespace App.Scripts.Infrastructure.LevelSelection
{
    [Serializable]
    public class ConfigLevelSelection
    {
        public int InitLevelIndex = 1;
        public List<ViewMap> Levels;
    }
}