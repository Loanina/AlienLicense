using System.Collections.Generic;
using App.Scripts.Feature.Models.View.ViewMap;

namespace App.Scripts.Feature.ProviderLevels
{
    public interface IProviderLevel
    {
        ViewMap LoadLevel(int index, List<ViewMap> levels);
    }
}