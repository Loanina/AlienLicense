using App.Scripts.Infrastructure.GameCore.Commands.SwitchLevel;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.Systems;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameCore.Systems
{
    public class SystemProcessNextLevel : ISystem
    {
        private readonly ICommandSwitchLevel _commandSwitchLevel;
        private readonly ViewLevelHeader _levelHeader;

        private int _requestSwitchLevel;

        public SystemProcessNextLevel(ViewLevelHeader levelHeader, ICommandSwitchLevel commandSwitchLevel)
        {
            _levelHeader = levelHeader;
            _commandSwitchLevel = commandSwitchLevel;
        }

        public void Update(float dt)
        {
            CheckSwitchLevel();
        }

        public void Init()
        {
            Debug.Log("Доделать");
        }

        public void Cleanup()
        {
            Debug.Log("Доделать");
        }

        private void CheckSwitchLevel()
        {
            if (_requestSwitchLevel == 0) return;

            _commandSwitchLevel.Execute(_requestSwitchLevel);
            _requestSwitchLevel = 0;
        }

        private void SwitchLevel(int value)
        {
            _requestSwitchLevel = value;
        }
    }
}