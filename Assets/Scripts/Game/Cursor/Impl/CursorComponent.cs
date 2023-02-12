using Game.Grid.Data;
using UnityEngine;

namespace Game.Cursor.Impl
{
    public class CursorComponent : MonoBehaviour
    {
        [SerializeField]
        private Joint _joint;
        [SerializeField]
        private Rigidbody _rigidbody;

        private IBuilding _holdingObject;
        
        public bool IsEmpty()
        {
            return _holdingObject == null;
        }

        public bool TryConnectToCursor(IBuilding building)
        {
            if (!IsEmpty())
            {
                return false;
            }

            _joint.connectedBody = building.GetRigidbody();
            building.SetCollisions(false);
            return true;
        }

        public bool TryReleaseFromCursor(out IBuilding building)
        {
            if (IsEmpty())
            {
                building = null;
                return false;
            }

            building = _holdingObject;
            _holdingObject.ResetRigidbody();
            building.SetCollisions(true);
            _holdingObject = null;
            return true;
        }

        public void SetPosition(Vector3 position)
        {
            _rigidbody.MovePosition(position);
        }
    }
}