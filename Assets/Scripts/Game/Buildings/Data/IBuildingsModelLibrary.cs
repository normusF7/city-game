using System.Collections.Generic;
using UnityEngine;

namespace Game.Buildings.Data
{
    public interface IBuildingsModelLibrary
    {
        IReadOnlyList<GameObject> HousePrefabs { get; }
    }
}