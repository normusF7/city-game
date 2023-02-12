using Game.Grid.Data;
using UnityEngine;

namespace Game.Cursor.Impl
{
    public class CursorApi : ICursorApi
    {
        private readonly ICursorService _cursorService;

        public CursorApi(ICursorService cursorService)
        {
            _cursorService = cursorService;
        }

        public bool IsEmpty()
        {
            return _cursorService.IsEmpty();
        }

        public bool TryConnectToCursor(IBuilding building)
        {
            return _cursorService.TryConnectToCursor(building);
        }

        public bool TryReleaseFromCursor(out IBuilding building)
        {
            return _cursorService.TryReleaseFromCursor(out building);
        }

        public void SetPosition(Vector3 position)
        {
            _cursorService.SetPosition(position);
        }
    }
}