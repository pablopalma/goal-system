using Assets.Code.Datas.ItemDatas;
using Assets.Code.Interfaces.PlayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Models.PlayerModels
{
    public class PlayerInventoryModel
    {
        private List<ItemData> _items;
        private List<ISlot> _slots = new List<ISlot>();

        public PlayerInventoryModel()
        {
            _items = new List<ItemData>();
        }

        public void AddSlot(ISlot slot)
        {
            _slots.Add(slot);   
        }

        // Agregar un item al inventario
        public void AddItem(ItemData item)
        {
            _items.Add(item);
        }

        // Eliminar un item del inventario
        public void RemoveItem(ItemData item)
        {
            if (_items.Contains(item))
                _items.Remove(item);
        }

        // Obtener todos los items en el inventario
        public List<ItemData> GetItems()
        {
            return _items;
        }

        // Verificar si el inventario tiene un item específico
        public bool HasItem(ItemData item)
        {
            return _items.Contains(item);
        }

        public List<ISlot> GetSlots()
        {
            return _slots;
        }
    }
}
