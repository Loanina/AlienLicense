using App.Scripts.Libs.BaseView;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Feature.FurnitureModels.View.ViewGridFurniture
{
    public class ViewGridFurniture : MonoViewUI
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private RectTransform container;
            
        [SerializeField] private AnimatorGridFurniture animator;
        
        
    }
}
