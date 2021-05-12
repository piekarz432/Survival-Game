using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private Slider healthSlider;

    public float attackRange = 0.5f;

    [SerializeField]
    private int maxHealth;

    public LayerMask enemyLayer;

    private int currentHealth;

    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Hurt enemy");

        currentHealth -= damage;
        healthSlider.value = currentHealth;

        animator.SetTrigger("hurt");

        if(currentHealth <= 0)
        {
            healthSlider.gameObject.SetActive(false);
            StartCoroutine(die());
        }
    }

    private IEnumerator die()
    {

        Debug.Log("Enemy die");

        animator.SetBool("isDead", true);
        gameObject.GetComponent<EnemyController>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(4f);
        GetComponent<DoWork>().finishWork(GetComponent<DoWork>().Names);
        Destroy(gameObject);
    }

    public void walk()
    {
        animator.SetBool("walk", true);
        animator.SetBool("attack", false);
    }

    public void attack()
    {
        
            animator.SetBool("attack", true);

            Collider[] hitEnemis = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider enemy in hitEnemis)
            {
                enemy.GetComponent<PlayerController>().survivalUIController.UpdateHealth("Damage", 2);
                enemy.GetComponent<PlayerController>().hurt();
            }


        }

    public void idle()
    {
        animator.SetBool("walk", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
