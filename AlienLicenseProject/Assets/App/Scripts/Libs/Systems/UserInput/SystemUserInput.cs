using App.Scripts.Feature.Inputs;
using UnityEngine;

namespace App.Scripts.Libs.Systems.UserInput
{
    public class SystemUserInput : ISystem
    {
        private readonly ContainerSwitchInput _containerSwitchInput;
        
        public SystemUserInput(ContainerSwitchInput containerSwitchInput)
        {
            _containerSwitchInput = containerSwitchInput;
        }
        
        public void Init()
        {
        }

        public void Update(float dt)
        {
            ClearInput();

            if (!Input.GetMouseButtonUp(0)) return;

            else Debug.Log("Клавиша поднялась");
            // var worldPosition = _viewCamera.ScreenToWorld(Input.mousePosition);

            // if (TryGetClickCell(worldPosition, out var clickedCell)) _containerSwitchInput.AddClickCell(clickedCell);
        }

        public void Cleanup()
        {
            ClearInput();
        }
        
        private void ClearInput()
        {
            _containerSwitchInput.Refresh();
        }
    }
}
