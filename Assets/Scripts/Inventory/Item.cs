using UnityEngine;
public enum PickupType { None, DamageObject, HealObject, HungerObject, ThirstObject, StaminaObject }

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite image;

    public string itemName;

    public PickupType type;

    public int itemValue;

    public AudioClip audioClip;

    public virtual void use()
    {
        Debug.Log("Using" + name);
    }

}
