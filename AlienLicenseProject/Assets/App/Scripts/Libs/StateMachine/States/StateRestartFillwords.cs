using System.Threading.Tasks;
using App.Scripts.Feature.Models.View.ViewMap;
using App.Scripts.Libs.StateMachine.States.SetupState;
using App.Scripts.Libs.TaskExtensions;

namespace App.Scripts.Libs.StateMachine.States
{
    public class StateRestart : GameState
    {
        private readonly ViewMap _viewMap;

        public StateRestart(ViewMap viewMap)
        {
            _viewMap = viewMap;
        }

        public override void OnEnterState()
        {
            ProcessHide().Forget();
        }

        private async Task ProcessHide()
        {
            StateMachine.ChangeState<StateSetupLevel>();
        }
    }
}