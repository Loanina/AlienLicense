using System.Collections.Generic;
using App.Scripts.Feature.Models.View.ViewMap;

namespace App.Scripts.Feature.ProviderLevels
{
    public class ProviderLevel : IProviderLevel
    {
        public ViewMap LoadLevel(int index, List<ViewMap> levels)
        {
            if (index > 0 && index <= levels.Count)
                return levels[index - 1];
            return null;
        }
    }
}
