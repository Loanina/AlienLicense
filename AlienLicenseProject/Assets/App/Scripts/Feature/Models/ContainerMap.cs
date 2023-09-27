using App.Scripts.Feature.Models.View.ViewMap;

namespace App.Scripts.Feature.Models
{
    public class ContainerMap
    {
        public ViewMap Map { get; private set; }
        public int LevelId { get; private set; }

        public void SetupMap(ViewMap map, int levelNumber)
        {
            LevelId = levelNumber;
            Map = map;
        }
    }
}


