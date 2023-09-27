using System.Threading.Tasks;
using App.Scripts.Feature.Models;
using App.Scripts.Feature.Models.View.ViewMap;
using App.Scripts.Infrastructure.LevelSelection;
using UnityEngine;

namespace App.Scripts.Libs.StateMachine.States.SetupState
{
    public class HandlerSetup : IHandlerSetupLevel
    {
        private readonly ContainerMap _containerMap;
        private readonly IServiceLevelSelection _serviceLevelSelection;

        public HandlerSetup(IServiceLevelSelection serviceLevelSelection,
            ContainerMap containerMap)
        {
            _serviceLevelSelection = serviceLevelSelection;
            _containerMap = containerMap;
        }

        public Task Process()
        {
            var model = _serviceLevelSelection.CurrentLevel;

            //_viewMap.UpdateItems(model);
            Debug.Log("Исправь как завершишь ViewMap");
            _containerMap.SetupMap(model, _serviceLevelSelection.CurrentLevelIndex);
            return Task.CompletedTask;
        }
    }
}