using App.Scripts.Libs.BaseView;
using UnityEngine;

namespace App.Scripts.Feature.FurnitureModels.View.ViewMap
{
    public class ViewMap : MonoViewUI
    {
        public void SetupSize(Vector2 itemSize)
        {
            RectTransform.sizeDelta = itemSize;
        }
    }
}