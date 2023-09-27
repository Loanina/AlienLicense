using System.Threading.Tasks;
using App.Scripts.Feature.Models;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using UnityEngine;

namespace App.Scripts.Libs.StateMachine.States.SetupState
{
    public class HandlerSetupShowLevel : IHandlerSetupLevel
    {
        private readonly ContainerMap _containerMap;
        private readonly ViewLevelHeader _viewLevelHeader;

        public HandlerSetupShowLevel(ContainerMap containerGrid, ViewLevelHeader viewLevelHeader)
        {
            _containerMap = containerGrid;
            _viewLevelHeader = viewLevelHeader;
        }

        public Task Process()
        {
            var animateLabel = _viewLevelHeader.UpdateLevelLabelAnimate(_containerMap.LevelId.ToString());
           // var animateMapShow = _containerMap.Map.AnimateShow();
            Debug.Log("Сделать анимацию появления мебели");
            return Task.WhenAll(animateLabel);
        }
    }
}