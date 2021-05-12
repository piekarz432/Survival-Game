using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Button removeButton;

    [SerializeField]
    private Sprite emptySlotImage;

    [SerializeField]
    private SurvivalUIController uiController;

    private Item item;

    private void Start()
    {
        clear();
    }

    public void addItem(Item item)
    {
        this.item = item;
        icon.sprite = item.image;
        icon.enabled = true;
        icon.GetComponent<Button>().interactable = true;
        removeButton.interactable = true;
    }

    public void clear()
    {
        item = null;

        icon.sprite = emptySlotImage;
        icon.enabled = false;
        icon.GetComponent<Button>().interactable = false;
        removeButton.interactable = false;
    }

    public void onRemoveButton()
    {
        Inventory.instance.removeItem(item);
    }

    public void useItem()
    {
        if(item != null)
        {
            chechType();
            item.use();
            AudioSource.PlayClipAtPoint(item.audioClip, transform.position);
            Inventory.instance.removeItem(item);
            clear();
        }
    }

    private void chechType()
    {
        if (item.type == PickupType.HealObject)
        {
            uiController.UpdateHealth("Heal", item.itemValue);
        }

        if (item.type == PickupType.DamageObject)
        {
            uiController.UpdateHealth("Damage", item.itemValue);
        }

        if (item.type == PickupType.HungerObject)
        {
            uiController.UpdateVitals("Hunger", item.itemValue);
        }

        if (item.type == PickupType.ThirstObject)
        {
            uiController.UpdateVitals("Thirst", item.itemValue);
        }

        if (item.type == PickupType.StaminaObject)
        {
            uiController.UpdateStamina("StaminaItem", item.itemValue);
        }
    }
}
