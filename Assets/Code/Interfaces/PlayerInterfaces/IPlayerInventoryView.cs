using Assets.Code.Datas.ItemDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Interfaces.PlayerInterfaces
{
    public interface IPlayerInventoryView
    {
        void GetItem(ItemData item);
        void UseItem(ItemData item);
        void PickItem(ItemData item); 
        void RemoveItem(ItemData item);
        void ShowItems(List<ItemData> items);
        void ShowMessage(string message);
        void RefreshInventory(List<ItemData> item);
        void RefreshInventory(ItemData item);

    }
}
