using Assets.Code.Datas.ItemDatas;
using Assets.Code.Datas.PlayerDatas;
using Assets.Code.Interfaces.ItemInterfaces;
using Assets.Code.Interfaces.PlayerInterfaces;
using Assets.Code.Models.PlayerModels;
using Assets.Code.Views.PlayerViews.PlayerInventoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code.PlayerPresenters
{
    public class PlayerInventoryPresenter
    {
        private IPlayerInventoryView _view;
        private PlayerInventoryModel _model;
        private PlayerInventoryData _inventoryConfig;
        private Transform _inventoryGridContainer;

        public PlayerInventoryPresenter(PlayerInventoryView view, PlayerInventoryData inventoryConfig, Transform inventoryGrid)
        {
            _view = view;
            _model = new PlayerInventoryModel();
            _inventoryConfig = inventoryConfig;
            _inventoryGridContainer = inventoryGrid;
        }



        internal void InitializeInventory()
        {
            for (int i = 0; i < _inventoryConfig.slotsQuantity; i++)
            {
                GameObject newSlot = MonoBehaviour.Instantiate(_inventoryConfig.slotGraph);
                newSlot.transform.SetParent(_inventoryGridContainer, false);
               _model.AddSlot(newSlot.GetComponent<SlotView>());
            }
        }


        // Agregar un item al inventario
        public void AddItemToInventory(ItemData item)
        {
            _model.AddItem(item);
            _view.ShowMessage($"{item.name} added to inventory.");
            _view.RefreshInventory(item);
        }

        // Eliminar un item del inventario
        public void RemoveItemFromInventory(ItemData item)
        {
            if (_model.HasItem(item))
            {
                _model.RemoveItem(item);
                _view.ShowMessage($"{item.name} removed from inventory.");
                _view.RefreshInventory(_model.GetItems()); // Refrescar la vista con los items actualizados
            }
            else
            {
                _view.ShowMessage($"Item {item.name} not found in inventory.");
            }
        }


        public void TryPickupItem(Ray ray)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IPickupeable itemComponent = hit.collider.GetComponent<IPickupeable>();
                if (itemComponent != null)
                {
                    ItemData itemData = itemComponent.Pickup();
                    AddItemToInventory(itemData);

                    // Mover la lógica de destrucción aquí
                    MonoBehaviour.Destroy(hit.collider.gameObject);
                }
            }
        }

        // Mostrar todos los items en la vista
        public void ShowInventory()
        {
            List<ItemData> items = _model.GetItems();
            _view.ShowItems(items);  // Mostrar todos los ítems en la vista
        }

        public void GetItem(ItemData item)
        {
        }

        public void PickItem(ItemData item)
        {
        }

        public void RemoveItem(ItemData item)
        {
        }

        public void UseItem(ItemData item)
        {
        }

        public ISlot GetAvailableSlot()
        {
            ISlot availableSlot = _model.GetSlots().FirstOrDefault(s => s.IsAvailable());
            return availableSlot;
        }
    }
}
