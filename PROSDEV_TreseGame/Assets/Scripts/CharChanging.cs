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
    public Texture warrior;
    public Texture archer;
    public Texture healer;

    private Material currMaterial;
    private float nextAttackTime = 0f;
    private Vector3 attackArea = new Vector3(0.5f, 0, 0);
    private int activeAttackpoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        currMaterial = GameObject.Find("MainCharGFX").GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            changeClass(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            changeClass(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            changeClass(3);

        if (Input.GetKey(KeyCode.D))
            activeAttackpoint = 0;
        else if (Input.GetKey(KeyCode.A))
            activeAttackpoint = 1;

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("LMB Click");
                normalAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void normalAttack()
    {
        //play animation
        //detect enemies in range
        Collider[] hitEnemiesSide = Physics.OverlapSphere(attackPoints[activeAttackpoint].position, attackRange, enemyLayers);

        //damage enemies
        foreach(Collider enemy in hitEnemiesSide)
        {
            Debug.Log("Side: Hit " + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }
    }

    void changeClass(int changeInto)
    {
        switch (changeInto)
        {
            case 1: currMaterial.mainTexture = warrior;
                break;
            case 2: currMaterial.mainTexture = archer;
                break;
            case 3: currMaterial.mainTexture = healer;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoints == null)
            return;

        Gizmos.DrawWireSphere(attackPoints[0].position, attackRange);
        Gizmos.DrawWireSphere(attackPoints[1].position, attackRange);
    }
}
