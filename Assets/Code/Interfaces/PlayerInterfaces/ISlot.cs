using UnityEngine;

namespace Assets.Code.Interfaces.PlayerInterfaces
{
    public interface ISlot
    {
        bool IsAvailable();
        void SetAvailableStatus(bool available);
        void SetItem(Sprite itemIcon);
    }
}
