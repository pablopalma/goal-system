using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyObjectiveView key;
    public LevelView level;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            key.Interact();
        }

        if (Input.GetKey(KeyCode.A))
        {
            level.CheckLevelStatus();
        }
    }
}
