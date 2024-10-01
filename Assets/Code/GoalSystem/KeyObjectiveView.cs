using UnityEngine;

public class KeyObjectiveView : MonoBehaviour, IInteractable
{
    public Objective objective;
    public ItemData itemConfig;

    public void Interact()
    {
        objective.Complete();
    }
}
