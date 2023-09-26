using App.Scripts.Libs.BaseView;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Feature.FurnitureModels.View.ViewFurniture
{
    public class ViewFurniture : MonoViewUI
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private RectTransform container;
            
        [SerializeField] private AnimatorFurniture animator;
        
        
    }
}
