using System;
using Game.Grid.Data;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid.Impl
{
    public class GridRepository : IGridRepository
    {
        private const int Resolution = 20;
        
        private readonly IMutableCell[,] _cells = new IMutableCell[Resolution, Resolution];
        
        private IBuilding _clipboard;

        public GridRepository()
        {
            for (int i = 0; i < Resolution; i++)
            {
                for (int j = 0; j < Resolution; j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }
        
        public ICell GetCell(Vector2Int position)
        {
            if (position.x >= Resolution || position.y >= Resolution)
            {
                throw new ArgumentOutOfRangeException($"Max position is {Resolution - 1}");
            }

            return _cells[position.x, position.y];
        }

        public bool TrySetBuildingClipboard(IBuilding building)
        {
            if (_clipboard != null)
            {
                return false;
            }

            _clipboard = building;
            return true;
        }

        public bool TryGetBuildingClipboard(out IBuilding building)
        {
            if (_clipboard != null)
            {
                building = null;
                return false;
            }

            building = _clipboard;
            _clipboard = null;
            return true;
        }

        public bool TrySetBuildingFromClipboard(Vector2Int position)
        {
            if (!IsCellEmpty(position))
            {
                return false;
            }

            _cells[position.x, position.y].Building = _clipboard;
            _clipboard = null;
            return true;
        }

        public bool TrySetBuilding(IBuilding building, Vector2Int position)
        {
            if (!IsCellEmpty(position))
            {
                return false;
            }

            SetBuilding(building, position);
            return true;
        }
        
        public bool TryGetBuildingAtPosition(Vector2Int position, out IBuilding building)
        {
            if (IsCellEmpty(position))
            {
                building = null;
                return false;
            }

            building = GetBuilding(position);
            return true;
        }

        public bool TryGetPlacedBuildingAtPosition(Vector2Int position, out IPlacedBuilding building)
        {
            if (IsCellEmpty(position))
            {
                building = null;
                return false;
            }

            building = _cells[position.x, position.y].Building;
            return true;
        }

        public bool IsCellEmpty(Vector2Int position)
        {
            return _cells[position.x, position.y].Building == null;
        }

        public Vector2Int WorldPosToGrid(Vector3 worldPosition)
        {
            return new Vector2Int(Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.z));
        }

        private void SetBuilding(IBuilding building, Vector2Int position)
        {
            _cells[position.x, position.y].Building = building;
            building.SetPosition(new Vector3(position.x + 0.5f, 0f, position.y + 0.5f));
            building.SetCollisions(true);
        }

        private IBuilding GetBuilding(Vector2Int position)
        {
            var building = _cells[position.x, position.y].Building;
            _cells[position.x, position.y].Building = null;

            return building;
        }
    }
}