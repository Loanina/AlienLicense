using App.Scripts.Feature.Models;
using App.Scripts.Feature.ProviderLevels;
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
            container.SetService<IProviderLevel, ProviderLevel>(new ProviderLevel());

            container.SetServiceSelf(new ContainerMap());
        }
    }
}
