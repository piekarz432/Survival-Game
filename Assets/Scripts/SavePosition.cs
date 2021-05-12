using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(save());
    }

    // Update is called once per frame
    void Update()
    {
        checkHeight();
    }

    IEnumerator save()
    {
       while(true)
        {
            position = new Vector3(player.position.x, player.position.y, player.position.z);
            yield return new WaitForSeconds(6f);
        }
    }

    private void checkHeight()
    {
        if(player.position.y <= 1.5f )
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.position = position;
        }
        player.GetComponent<CharacterController>().enabled = true;
    }
}
