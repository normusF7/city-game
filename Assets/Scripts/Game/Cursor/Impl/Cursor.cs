using Game.Grid.Data;
using UnityEngine;

namespace Game.Cursor.Impl
{
    public class Cursor : ICursor
    {
        private readonly CursorComponent _cursorComponent;

        public Cursor(GameObject prefab)
        {
            _cursorComponent = Object.Instantiate(prefab, Vector3.zero, Quaternion.Euler(new Vector3(-90, 0, 0)))
                .GetComponent<CursorComponent>();
        }

        public bool IsEmpty()
        {
           return _cursorComponent.IsEmpty();
        }

        public bool TryConnectToCursor(IBuilding building)
        {
            return _cursorComponent.TryConnectToCursor(building);
        }

        public bool TryReleaseFromCursor(out IBuilding building)
        {
            return _cursorComponent.TryReleaseFromCursor(out building);
        }

        public void SetPosition(Vector3 position)
        {
            _cursorComponent.SetPosition(position);
        }
    }
}