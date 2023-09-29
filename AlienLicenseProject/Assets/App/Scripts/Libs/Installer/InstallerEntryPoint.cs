using System.Collections.Generic;
using App.Scripts.Feature.Models;
using App.Scripts.Feature.Models.View.ViewMap;
using App.Scripts.Feature.Models.View.ViewMapContainer;
using App.Scripts.Infrastructure.GameCore.Commands.SwitchLevel;
using App.Scripts.Infrastructure.GameCore.Controllers;
using App.Scripts.Infrastructure.GameCore.Systems;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.ServiceLocator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.StateMachine.States;
using App.Scripts.Libs.StateMachine.States.SetupState;
using App.Scripts.Libs.Systems;

namespace App.Scripts.Libs.Installer
{
    public class InstallerEntryPoint : MonoInstaller
    {
        public override void InstallBindings(ServiceContainer container)
        {
            var gameStateMachine = BuildStateMachine(container);
            var controllerEntryPoint = new ControllerEntryPoint<StateSetupLevel>(gameStateMachine);

            container.SetService<IInitializable, ControllerEntryPoint<StateSetupLevel>>(controllerEntryPoint);
            container.SetService<IUpdatable, ControllerEntryPoint<StateSetupLevel>>(controllerEntryPoint);
        }
        
        private GameStateMachine BuildStateMachine(ServiceContainer container)
        {
            var gameStateMachine = new GameStateMachine();

            gameStateMachine.AddState(CreateStateSetupLevel(container));
            gameStateMachine.AddState(CreateProcessState(container, gameStateMachine));
            gameStateMachine.AddState(CreateRestartState(container, gameStateMachine));

            return gameStateMachine;
        }

        private GameState CreateRestartState(ServiceContainer container, GameStateMachine gameStateMachine)
        {
            return new StateRestart(container.Get<ViewMap>());
        }

        private GameState CreateStateSetupLevel(ServiceContainer container)
        {
            var handlers = new List<IHandlerSetupLevel>
            {
                new HandlerSetup(
                    container.Get<IServiceLevelSelection>(),
                    container.Get<ContainerMap>()),
                new HandlerSetupShowLevel(container.Get<ContainerMap>(), container.Get<ViewLevelHeader>(),
                    container.Get<ViewMapContainer>())
            };

            var handlerStateSetup = new HandlerSetupLevelContainer(handlers);

            var stateSetupLevel = new StateSetupLevel(handlerStateSetup);

            return stateSetupLevel;
        }

        private GameState CreateProcessState(ServiceContainer container, GameStateMachine gameStateMachine)
        {
            var systems = new SystemsGroup();
            systems.AddSystems(container.GetServices<ISystem>());

            var commandSwitchLevel = new CommandSwitchLevelState<StateRestart>(
                container.Get<IServiceLevelSelection>(),
                gameStateMachine);

            systems.AddSystem(new SystemProcessNextLevel(
                container.Get<ViewLevelHeader>(),
                commandSwitchLevel));

            var stateProcess = new StateProcessGame(systems);
            return stateProcess;
        }
    }
}