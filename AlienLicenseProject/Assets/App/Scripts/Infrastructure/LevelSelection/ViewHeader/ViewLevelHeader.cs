using System;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Infrastructure.LevelSelection.ViewHeader
{
    public class ViewLevelHeader : MonoBehaviour, IDisposable
    {
        [SerializeField] private AnimatorHeader animator;
        
        public Task UpdateLevelLabelAnimate(string levelInfo)
        {
            return animator.AnimateChangeLabel(levelInfo);
        }

        public void Dispose()
        {
            animator.CancelAnimation();
        }
    }
}