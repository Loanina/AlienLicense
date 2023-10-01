using System;
using App.Scripts.Infrastructure.ShaderViews.Animator;
using UnityEngine;

namespace App.Scripts.Feature.Models.View.ViewFurniture
{
    public class AnimatorFurniture : BaseAnimatorTween
    {
        [SerializeField] private AnimatorConfig config;
        
        [SerializeField] private BoxCollider2D boxCollider;
        [SerializeField] private Rigidbody2D rb;
        
        
        
        
        [Serializable]
        public class AnimatorConfig
        {
            public float selectScale = 1.2f;
            public float durationSelect = 0.3f;
        }
    }
}
