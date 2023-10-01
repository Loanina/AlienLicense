
using App.Scripts.Infrastructure.GameCore.Models;
using UnityEngine;

namespace App.Scripts.Feature.Inputs
{
    public class ContainerSwitchInput : ContainerUpdatable
    {
        public Vector2Int To { get; private set; }

        public void AddClickCell(Vector2Int to)
        {
            To = to;
            NotifyUpdate();
        }
    }
}
