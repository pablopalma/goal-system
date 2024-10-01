using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create New Item")]
public class ItemData : ScriptableObject
{
    public string name;
    public string desciption;
    public bool isStackable;
    public float weight;
    public float price;
    public bool isDroppable;
}
