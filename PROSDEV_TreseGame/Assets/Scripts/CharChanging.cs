using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharChanging : MonoBehaviour
{
    //attack point order: Right, Up, Down, Left
    public List<Transform> attackPoints = new List<Transform>();
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float attackRate = 2f;

    private float nextAttackTime = 0f;
    private Vector3 attackArea = new Vector3(0.5f, 0, 0);
    private int activeAttackpoint = 0;

    private enum Jobs {
    Warrior,
    Archer,
    Healer
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            activeAttackpoint = 0;
        else if (Input.GetKey(KeyCode.A))
            activeAttackpoint = 3;

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("LMB Click");
                NormalAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void NormalAttack()
    {
        //play animation
        //detect enemies in range
        Collider[] hitEnemiesSide = Physics.OverlapSphere(attackPoints[activeAttackpoint].position, attackRange, enemyLayers);
        Collider[] hitEnemiesUp = Physics.OverlapSphere(attackPoints[1].position, attackRange, enemyLayers);
        Collider[] hitEnemiesDown = Physics.OverlapSphere(attackPoints[2].position, attackRange, enemyLayers);

        //damage enemies
        foreach(Collider enemy in hitEnemiesSide)
        {
            Debug.Log("Side: Hit " + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }
        foreach (Collider enemy in hitEnemiesUp)
        {
            Debug.Log("Up: Hit " + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }
        foreach (Collider enemy in hitEnemiesDown)
        {
            Debug.Log("Down: Hit " + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoints == null)
            return;

        Gizmos.DrawWireSphere(attackPoints[0].position, attackRange);
        Gizmos.DrawWireSphere(attackPoints[1].position, attackRange);
        Gizmos.DrawWireSphere(attackPoints[2].position, attackRange);
        Gizmos.DrawWireSphere(attackPoints[3].position, attackRange);
    }
}
