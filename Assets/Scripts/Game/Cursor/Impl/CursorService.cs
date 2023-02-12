using Game.Grid.Data;
using UnityEngine;

namespace Game.Cursor.Impl
{
    public class CursorService : ICursorService
    {
        private readonly ICursor _cursor;

        public CursorService(GameObject cursorPrefab)
        {
            _cursor = new Cursor(cursorPrefab);
        }

        public bool IsEmpty()
        {
            return _cursor.IsEmpty();
        }

        public bool TryConnectToCursor(IBuilding building)
        {
            return _cursor.TryConnectToCursor(building);
        }

        public bool TryReleaseFromCursor(out IBuilding building)
        {
            return _cursor.TryReleaseFromCursor(out building);
        }

        public void SetPosition(Vector3 position)
        {
            _cursor.SetPosition(position);
        }
    }
}