using System.Collections.Generic;
using UnityEngine;

namespace Game.Buildings.Data.Impl
{
    [CreateAssetMenu(fileName = "Library", menuName = "ScriptableObjects/BuildingsModelLibrary", order = 1)]
    public class BuildingsModelLibrary : ScriptableObject, IBuildingsModelLibrary
    {
        public List<GameObject> housePrefabs;

        public IReadOnlyList<GameObject> HousePrefabs => housePrefabs;
    }
}