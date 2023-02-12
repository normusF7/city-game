using Game.Grid.Data;
using UnityEngine;

namespace Game.Cursor
{
    public interface ICursor
    {
        bool IsEmpty();
        bool TryConnectToCursor(IBuilding building);
        bool TryReleaseFromCursor(out IBuilding building);
        void SetPosition(Vector3 position);
    }
}