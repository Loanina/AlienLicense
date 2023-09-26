using App.Scripts.Libs.ServiceLocator;

namespace App.Scripts.Libs.Installer
{
    public abstract class MonoInstaller
    {
        public abstract void InstallBindings(ServiceContainer serviceContainer);
    }
}