using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackRate = 2f;

    [SerializeField]
    private AudioClip audioClip;

    private float nextAttackTime = 0f;

    private Animator anim;

    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    public bool isAttack = false;

    public bool IsAttack { get => isAttack; }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    private void attack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<PlayerWeapon>().IsCollect)
            {
                anim.SetTrigger("attack1");
           
                Collider[] hitEnemis = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

                foreach (Collider enemy in hitEnemis)
                {
                    enemy.GetComponent<Enemy>().takeDamage(20);
                }
                
                nextAttackTime = Time.time + 1f / attackRate;
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                isAttack = true;
            }
        }

        isAttack = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void setAttackPoint(Transform attackPoint)
    {
        this.attackPoint = attackPoint;
    }

}
