using Assets.Code.Interfaces.PlayerInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Views.PlayerViews.PlayerInventoryView
{
    public class SlotView : MonoBehaviour, ISlot
    {
        public bool _isAvailable;
        [SerializeField] private Image _itemIcon;

        public bool IsAvailable()
        {
            return _isAvailable;
        }

        public void SetAvailableStatus(bool available)
        {
            _isAvailable = available;
        }

        public void SetItem(Sprite itemIcon)
        {
            _itemIcon.enabled = true;
            SetAvailableStatus(false);
            _itemIcon.sprite = itemIcon;
        }
    }
}
