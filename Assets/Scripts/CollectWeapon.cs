using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    [SerializeField]
    private PlayerWeapon playerWeapon;

    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private GameObject tickParticle;

    private bool isLight = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (transform.tag == "Sword")
            {
                playerWeapon.Sword = gameObject;
                playerWeapon.setSwordPostion();
                var objects = GetComponentsInChildren<Transform>();

                foreach (Transform t in objects)
                {
                    if (t.name == "Spark (1)(Clone)")
                    {
                        Destroy(t.gameObject);
                    }

                    if (t.name == "Trails")
                    {
                        t.GetComponent<ParticleSystem>().Play();
                    }

                }
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                GetComponent<DoWork>().finishWork(GetComponent<DoWork>().Names);
            }

            if (transform.tag == "Shield")
            {
                playerWeapon.Shield = gameObject;
                playerWeapon.setShieldPostion();

                var objects = GetComponentsInChildren<Transform>();

                foreach (Transform t in objects)
                {
                    if (t.name == "Spark (1)(Clone)")
                    {
                        Destroy(t.gameObject);
                    }
                }
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                GetComponent<DoWork>().finishWork(GetComponent<DoWork>().Names);

            }
        }

        if (other.tag == "FlyingLight" && !isLight)
        {
            Debug.Log("asdasdasd");
            var obj = Instantiate(tickParticle);
            obj.transform.parent = gameObject.transform;
            obj.transform.position = gameObject.transform.position;

            if (transform.tag == "Sword")
            {
                obj.transform.position = gameObject.transform.localPosition - new Vector3(0.08f, -0.5f, -0.2f);
            }

            gameObject.GetComponent<CollectWeapon>().isLight = true;
        }
    }
}
