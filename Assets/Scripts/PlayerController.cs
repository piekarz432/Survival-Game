using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;

    public SurvivalUIController survivalUIController;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float sprintSpeed;

    [SerializeField]
    private Camera myCamera;

    [SerializeField]
    private float rotationSpeed = 15;

    [SerializeField]
    private float animationBlendSpeed = 5f;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private Transform sword;

    [SerializeField]
    private GameObject light;

    private CharacterController characterController;

    private float mDesiredRotation = 0f;

    private float mDesiredAnimationSpeed = 0f;

    private bool sprinting = false;

    private float speedY = 0;

    private float gravity = -9.81f;

    private bool jumping = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("click");
            showLight();
        }


    }


    private void move()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("NormalAttack01_SwordShield"))
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Jump") && !jumping && survivalUIController.playerStamina >= (survivalUIController.maxStamina * 20 / 100))
            {
                jumping = true;

                anim.SetTrigger("Jump");

                survivalUIController.StaminaJump();

                speedY += jumpSpeed;
            }

            if (!characterController.isGrounded)
            {
                speedY += gravity * Time.deltaTime;
            }
            else if (speedY < 0)
            {
                speedY = 0;
            }

            anim.SetFloat("jump", speedY / jumpSpeed);

            sprinting = Input.GetKey(KeyCode.LeftShift);

            Vector3 movement = new Vector3(x, 0, z).normalized;

            Vector3 rotatedMovement = Quaternion.Euler(0, myCamera.transform.rotation.eulerAngles.y, 0) * movement;
            Vector3 verticalMovement = Vector3.up * speedY;

            if (sprinting)
            {
                if (survivalUIController.playerStamina > 0)
                {
                    characterController.Move((verticalMovement + (rotatedMovement * sprintSpeed)) * Time.deltaTime);
                    survivalUIController.Sprinting();
                }
                else if (survivalUIController.playerStamina <= 0)
                {
                    survivalUIController.weAreSprinting = false;
                    sprinting = false;
                    characterController.Move((verticalMovement + (rotatedMovement * moveSpeed)) * Time.deltaTime);
                }
            }
            else
            {
                survivalUIController.weAreSprinting = false;
                characterController.Move((verticalMovement + (rotatedMovement * moveSpeed)) * Time.deltaTime);
            }

            if (rotatedMovement.magnitude > 0)
            {
                GameObject.Find("InventoryPanel").GetComponent<InventoryUi>().hidePanel();

                mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                mDesiredAnimationSpeed = sprinting ? 1 : 0.5f;
            }
            else
            {
                mDesiredAnimationSpeed = 0;
            }

            anim.SetFloat("speed", Mathf.Lerp(anim.GetFloat("speed"), mDesiredAnimationSpeed, animationBlendSpeed * Time.deltaTime));
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }

    public void hurt()
    {
        anim.SetTrigger("hurt");
    }

    private void showLight()
    {
        var obj = Instantiate(light, new Vector3(transform.position.x, 3.0f, transform.position.z), transform.rotation);

        obj.GetComponent<FlyingLight>().fly(transform.rotation);
    }

}
