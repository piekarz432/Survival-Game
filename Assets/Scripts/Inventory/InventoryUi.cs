using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUi : MonoBehaviour
{
    [SerializeField]
    private Transform itemsParent;

    private Inventory inventory;

    private InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUi;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            showPanel();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            hidePanel();
        }
    }

    void UpdateUi()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clear();
            }
        }
    }

    private void showPanel()
    {
        GetComponent<Animator>().Play("InventoryPanelUp");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void hidePanel()
    {
        GetComponent<Animator>().Play("InventoryPanelDown");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
