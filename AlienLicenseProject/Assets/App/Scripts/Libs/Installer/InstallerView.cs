using System;
using App.Scripts.Feature.Models.View.ViewFurniture;
using App.Scripts.Feature.Models.View.ViewMap;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Libs.Installer
{
    public class InstallerView : MonoInstaller
    {
        [SerializeField] private ViewMap map;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            serviceContainer.SetServiceSelf(map);
        }
    }
}
