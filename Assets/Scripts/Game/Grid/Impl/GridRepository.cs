using System;
using Game.Grid.Data;
using Game.Grid.Data.Impl;
using UnityEngine;

namespace Game.Grid.Impl
{
    public class GridRepository : IGridRepository
    {
        private const int Resolution = 20;
        
        private IMutableCell[,] _cells = new IMutableCell[Resolution, Resolution];
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

        private bool IsCellEmpty(Vector2Int position)
        {
            return _cells[position.x, position.y].Building == null;
        }

        private void SetBuilding(IBuilding building, Vector2Int position)
        {
            _cells[position.x, position.y].Building = building;
            building.SetPosition(new Vector3(position.x + 0.5f, 0.25f, position.y + 0.5f));
        }
    }
}