using System;
using UnityEngine;

namespace Game.Grid.Data
{
    public interface IBuilding : IPlacedBuilding, IDisposable
    {
        void SetPosition(Vector3 position);
        void ResetRigidbody();
        void SetCollisions(bool enabled);
        Rigidbody GetRigidbody();
    }
}