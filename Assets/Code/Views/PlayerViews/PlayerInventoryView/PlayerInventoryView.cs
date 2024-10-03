using Assets.Code.Datas.ItemDatas;
using Assets.Code.Datas.PlayerDatas;
using Assets.Code.Interfaces.ItemInterfaces;
using Assets.Code.Interfaces.PlayerInterfaces;
using Assets.Code.PlayerPresenters;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Views.PlayerViews.PlayerInventoryView
{
    public class PlayerInventoryView : MonoBehaviour, IPlayerInventoryView
    {
        private PlayerInventoryPresenter _presenter;

        [SerializeField] private PlayerInventoryData _inventoryConfig;
        [SerializeField] private Transform _inventoryGrid;
        [SerializeField] private float pickupRange;
        [SerializeField] GameObject inventory;


        private void Awake()
        {
            // Inicializar el presentador
            _presenter = new PlayerInventoryPresenter(this, _inventoryConfig, _inventoryGrid);
        }

        private void Start()
        {
            // Inicializar el inventario
            _presenter.InitializeInventory();
        }

        private void Update()
        {
            // Detectar si el jugador está intentando recoger un item
            if (Input.GetMouseButtonDown(0))
            {
                TryPickupItem();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inventory.SetActive(!inventory.activeSelf);
            }
        }

        private void TryPickupItem()
        {
            // Ray desde la cámara al punto donde está el mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Realizar un raycast para detectar si clickeamos en algo
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Verificar si el objeto clickeado tiene el componente IPickupeable
                IPickupeable itemComponent = hit.collider.GetComponent<IPickupeable>();

                if (itemComponent != null)
                {
                    // Recoger el item y añadirlo al inventario
                    ItemData itemData = itemComponent.Pickup();
                    _presenter.AddItemToInventory(itemData);

                    // Destruir el objeto del mundo
                    Destroy(hit.collider.gameObject); // Destruir el objeto recogido
                }
            }
        }

        // Este método se llamará cuando se deba refrescar el inventario visual
        public void RefreshInventory(List<ItemData> items)
        {
            // Regenerar la vista del inventario basado en los ítems
            foreach (ItemData item in items)
            {
                // Instanciar un nuevo GameObject para representar el ítem
                GameObject itemIcon = new GameObject("ItemIcon");

                // Añadir el componente de imagen
                Image iconImage = itemIcon.AddComponent<Image>();

                // Asignar el ícono del `ItemData` (que es un Sprite)
                iconImage.sprite = item.icon;

                // Ajustar el ícono en la jerarquía del inventario (dentro de un slot)
                itemIcon.transform.SetParent(_inventoryGrid, false);
            }
        }

        public void RefreshInventory(ItemData item)
        {
            ISlot slot = _presenter.GetAvailableSlot();

            if (slot == null) return;

            // Regenerar la vista del inventario basado en los ítems
            GameObject itemIcon = new GameObject("ItemIcon");

            // Añadir el componente de imagen
            Image iconImage = itemIcon.AddComponent<Image>();

            // Asignar el ícono del `ItemData` (que es un Sprite)
            iconImage.sprite = item.icon;

            // Ajustar el ícono en la jerarquía del inventario (dentro de un slot)
            slot.SetItem(iconImage.sprite);
        }

        public void ShowMessage(string message)
        {
            // Aquí podrías usar una interfaz gráfica para mostrar mensajes al jugador
            Debug.Log(message);
        }

        // Métodos restantes del IPlayerInventoryView
        public void GetItem(ItemData item)
        {
            // Aquí podrías manejar la lógica de obtener un ítem
        }

        public void PickItem(ItemData item)
        {
            _presenter.AddItemToInventory(item);
        }

        public void RemoveItem(ItemData item)
        {
            _presenter.RemoveItemFromInventory(item);
        }

        public void UseItem(ItemData item)
        {
            // Aquí podrías manejar la lógica de usar un ítem
        }

        public void ShowItems(List<ItemData> items)
        {
            // Este método puede ser utilizado para mostrar todos los ítems en el inventario
            RefreshInventory(items);
        }
    }
}
