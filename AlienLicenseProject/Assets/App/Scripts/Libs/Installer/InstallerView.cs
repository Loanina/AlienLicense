using App.Scripts.Feature.Models.View.ViewMapContainer;
using App.Scripts.Infrastructure.LevelSelection.ViewHeader;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Libs.Installer
{
    public class InstallerView : MonoInstaller
    {
        [SerializeField] private ViewLevelHeader viewLevelHeader;
        [SerializeField] private ViewMapContainer viewMapContainer;
        
        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(viewLevelHeader);
            serviceContainer.SetServiceSelf(viewMapContainer);
        }
    }
}