using App.Scripts.Libs.BaseView;
using App.Scripts.Libs.Factory;
using UnityEngine;

namespace App.Scripts.Feature.Models.View.ViewMapContainer
{
    public class ViewMapContainer : MonoViewUI
    {
        [SerializeField] private RectTransform container;
        
        private IFactory<ViewMap.ViewMap> _factoryViewMap;

        private ViewMap.ViewMap _viewMap;

        public void ConstructViewMap(IFactory<ViewMap.ViewMap> factoryViewMap)
        {
            _factoryViewMap = factoryViewMap;
        }

        public void CreateViewMap()
        {
            _viewMap = _factoryViewMap.Create();
            _viewMap.SetParent(container);
            _viewMap.SetScale(Vector3.one);

            _viewMap.RectTransform.localPosition = Vector3.zero; 
        }
    }
}
