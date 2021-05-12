using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {

        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    [SerializeField]
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private const int SPACE = 5;

    public bool addItem(Item item)
    {
        if(items.Count >= SPACE)
        {
            return false;
        }

        items.Add(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void removeItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
