using System.Collections.Generic;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Libs.ServiceLocator;

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
            return new StateRestartFillwords(container.Get<ViewGridLetters>());
        }

        private GameState CreateStateSetupLevel(ServiceContainer container)
        {
            var handlers = new List<IHandlerSetupLevel>
            {
                new HandlerSetupFillwords(container.Get<IProviderFillwordLevel>(),
                    container.Get<IServiceLevelSelection>(),
                    container.Get<ViewGridLetters>(),
                    container.Get<ContainerGrid>()),
                new HandlerSetupShowLevel(container.Get<ViewLevelHeader>(), container.Get<ViewGridLetters>(),
                    container.Get<ContainerGrid>())
            };

            var handlerStateSetup = new HandlerSetupLevelContainer(handlers);

            var stateSetupLevel = new StateSetupLevel(handlerStateSetup);

            return stateSetupLevel;
        }

        private GameState CreateProcessState(ServiceContainer container, GameStateMachine gameStateMachine)
        {
            var systems = new SystemsGroup();
            systems.AddSystems(container.GetServices<ISystem>());

            var commandSwitchLevel = new CommandSwitchLevelState<StateRestartFillwords>(
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