using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI keyText;

    void Start()
    {
        keyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateKeytext(PlayerInventory playerInventory)
    {
        keyText.text = playerInventory.KeysCollected.ToString();
    }
}
