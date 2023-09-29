using System.Threading.Tasks;
using App.Scripts.Feature.Models;
using App.Scripts.Feature.Models.View.ViewMap;
using App.Scripts.Feature.Models.View.ViewMapContainer;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.Factory.Mono;
using UnityEngine;

namespace App.Scripts.Libs.StateMachine.States.SetupState
{
    public class HandlerSetupShowLevel : IHandlerSetupLevel
    {
        private readonly ContainerMap _containerMap;
        private readonly ViewLevelHeader _viewLevelHeader;
        private readonly ViewMapContainer _viewMapContainer;

        public HandlerSetupShowLevel(ContainerMap containerMap, ViewLevelHeader viewLevelHeader, ViewMapContainer viewMapContainer)
        {
            _containerMap = containerMap;
            _viewLevelHeader = viewLevelHeader;
            _viewMapContainer = viewMapContainer;
        }

        public Task Process()
        {
            var animateLabel = _viewLevelHeader.UpdateLevelLabelAnimate(_containerMap.LevelId.ToString());
           // var animateMapShow = _containerMap.Map.AnimateShow();
           var map = _containerMap.Map;
           _viewMapContainer.ConstructViewMap(new FactoryMonoPrefab<ViewMap>(map));
           _viewMapContainer.CreateViewMap();
           Debug.Log("Сделать анимацию появления мебели");
            return Task.WhenAll(animateLabel);
        }
    }
}