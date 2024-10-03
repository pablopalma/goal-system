using Assets.Code.Interfaces.PlayerInterfaces;
using Assets.Code.Models.PlayerModels;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Datas.PlayerDatas
{
    [CreateAssetMenu(fileName = "New InventoryConfig", menuName = "Inventory System/Create New Inventory Config")]
    public class PlayerInventoryData : ScriptableObject
    {
        public GameObject slotGraph;
        public int slotsQuantity;
    }
}
