using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Datas.ItemDatas
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Create New Item")]
    public class ItemData : ScriptableObject
    {
        public string itemID;  // ID único para este item
        public string itemName;
        public string description;
        public bool isStackable;
        public float weight;
        public float price;
        public bool isDroppable;
        public Sprite icon;  // Usar Sprite en lugar de Image para simplificar la serialización
    }
}
