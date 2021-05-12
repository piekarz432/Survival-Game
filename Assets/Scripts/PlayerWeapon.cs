using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform swordPositon;

    [SerializeField]
    private Transform shieldPositon;

    private GameObject sword;

    private GameObject shield;

    private bool isCollect = false;

    public GameObject Sword { get => sword; set => sword = value; }
    public GameObject Shield { get => shield; set => shield = value; }
    public bool IsCollect { get => isCollect; set => isCollect = value; }

    public void setSwordPostion()
    {
        sword.transform.parent = swordPositon;
        sword.transform.localPosition = new Vector3(0.118816f, -0.02698418f, 0.007319052f);
        sword.transform.localRotation = Quaternion.Euler(-90.258f, -36.25299f, 36.04799f);
        sword.GetComponent<BoxCollider>().enabled = false;
        isCollect = true;
        GetComponent<PlayerAttack>().setAttackPoint(sword.transform.GetChild(0));
    }

    public void setShieldPostion()
    {
        shield.transform.parent = shieldPositon;
        shield.transform.localPosition = new Vector3(-0.1405784f, -0.04058702f, 0.0068397f);
        shield.transform.localRotation = Quaternion.Euler(89.741f, -36.252f, -36.047f);
        shield.GetComponent<BoxCollider>().enabled = false;
    }
}
