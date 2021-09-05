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
    private int activeAttackpoint = 0;
    private FireProjectiles fireProjectiles;
    private bool isRanged = false;

    //skill scripts
    private HealerSkill healerSkill;
    private SwordsmanSkill swordsmanSkill;
    private ArcherSkill archerSkill;

    // Start is called before the first frame update
    void Start()
    {
        healerSkill = GetComponent<HealerSkill>();
        swordsmanSkill = GetComponent<SwordsmanSkill>();
        archerSkill = GetComponent<ArcherSkill>();

        currMaterial = GameObject.Find("MainCharGFX").GetComponent<MeshRenderer>().material;
        fireProjectiles = GetComponent<FireProjectiles>();
        fireProjectiles.enabled = false;
        swordsmanSkill.enabled = true;
        healerSkill.enabled = false;
        archerSkill.enabled = false;
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

        //if (Input.GetKey(KeyCode.D))
        //    activeAttackpoint = 0;
        //else if (Input.GetKey(KeyCode.A))
        //    activeAttackpoint = 1;

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && !isRanged)
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
                fireProjectiles.enabled = false;
                swordsmanSkill.enabled = true;
                healerSkill.enabled = false;
                archerSkill.enabled = false;
                isRanged = false;
                break;
            case 2: currMaterial.mainTexture = archer;
                fireProjectiles.enabled = true;
                swordsmanSkill.enabled = false;
                healerSkill.enabled = false;
                archerSkill.enabled = true;
                isRanged = true;
                break;
            case 3: currMaterial.mainTexture = healer;
                fireProjectiles.enabled = true;
                swordsmanSkill.enabled = false;
                healerSkill.enabled = true;
                archerSkill.enabled = false;
                isRanged = true;
                break;
        }
    }

    public void setActivePoint(int activePoint)
    {
        this.activeAttackpoint = activePoint;
    }

    public int getActiveAttackPoint()
    {
        return this.activeAttackpoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(0.6f, 1, 0.05f));
        //if (attackPoints == null)
        //    return;

        //Gizmos.DrawWireSphere(attackPoints[activeAttackpoint].position, attackRange);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoints == null)
            return;

        Gizmos.DrawWireSphere(attackPoints[0].position, attackRange);
        Gizmos.DrawWireSphere(attackPoints[1].position, attackRange);
    }
}
