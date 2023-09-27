using System.Threading.Tasks;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Libs.StateMachine.States.SetupState
{
    public class StateSetupLevel : GameState
    {
        private readonly IHandlerSetupLevel _handlerSetup;

        public StateSetupLevel(IHandlerSetupLevel handlerSetupLevels)
        {
            _handlerSetup = handlerSetupLevels;
        }

        public override void OnEnterState()
        {
            ProcessSetupLevel().Forget();
        }

        private async Task ProcessSetupLevel()
        {
            await _handlerSetup.Process();

            StateMachine.ChangeState<StateProcessGame>();
        }
    }
}