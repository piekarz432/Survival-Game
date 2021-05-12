using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField]
    private Item item;

    [SerializeField]
    private SurvivalUIController uiController;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private GameObject tickParticle;

    private bool isLight = false;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Collect things
        if (other.tag == "Player")
        {
            bool wasPickedUp = Inventory.instance.addItem(item);
            
            if (wasPickedUp)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                Destroy(gameObject);
            }

        }
        #endregion

        if(other.tag == "FlyingLight" && !isLight)
        {
            var obj = Instantiate(tickParticle);
            obj.transform.parent = gameObject.transform;
            obj.transform.position = gameObject.transform.position;
            gameObject.GetComponent<PickupController>().isLight = true;
        }
    }


}
