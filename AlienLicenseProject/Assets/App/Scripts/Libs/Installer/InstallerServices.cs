using App.Scripts.Feature.Inputs;
using App.Scripts.Feature.Models;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Libs.Installer
{
    public class InstallerServices : MonoInstaller
    {
        [SerializeField] private ConfigLevelSelection configLevelSelection;

        public override void InstallBindings(ServiceContainer container)
        {
            container.SetService<IServiceLevelSelection, ServiceLevelSelection>(
                new ServiceLevelSelection(configLevelSelection));
            
            container.SetServiceSelf(new ContainerSwitchInput());
            container.SetServiceSelf(new ContainerMap());
        }
    }
}
