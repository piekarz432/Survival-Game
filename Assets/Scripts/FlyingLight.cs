using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLight : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float lifeTime = 3f;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }

        if(lifeTime <=0)
        {
            Destroy(gameObject);
        }
    }

    public void fly(Quaternion rotation)
    {
            rigidbody.velocity = rotation * Vector3.forward * speed;

    }

}
