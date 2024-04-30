using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int KeysCollected { get; private set; }

    public UnityEvent<PlayerInventory> OnKeyCollected;

    public void CollectKey()
    {
        KeysCollected++;
        OnKeyCollected.Invoke(this);
    }

}
