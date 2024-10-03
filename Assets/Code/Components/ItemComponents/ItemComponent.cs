using Assets.Code.Datas.ItemDatas;
using Assets.Code.Interfaces.ItemInterfaces;
using UnityEngine;

namespace Assets.Code.Components.ItemComponents
{
    public class ItemComponent : MonoBehaviour, IPickupeable
    {
        [SerializeField] private ItemData itemData;  // El ScriptableObject que define el item
        public ItemData GetItemData() => itemData;

        public ItemData Pickup()
        {
            return itemData;
        }
    }
}
