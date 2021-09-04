using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanSkill : MonoBehaviour
{
    //public float dashSpeed;
    public float dashTimer;
    public float dashDist;
    public float dashDuration;
    public LayerMask ignoreLayers;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float cooldown;

    bool dashing;
    Vector3 dashDir;

    private List<Transform> attackPoints = new List<Transform>();
    private Ray ray;
    private RaycastHit hit;
    private Rigidbody rb;
    private float nextDashTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackPoints = GetComponent<CharChanging>().attackPoints;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dashing && Time.time >= nextDashTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dash();
                nextDashTime = (Time.time + 1f) / cooldown;
                //attack();
            }
        }
    }
    
    void dash()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 dashDir = mousePos - this.transform.position;

        //dashDir.y = 0;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignoreLayers))
        {
            Vector3 mousePos = hit.point;
            mousePos.y = this.transform.position.y;
            this.dashDir = mousePos - this.transform.position;
        }

        //transform.position += dashDir * dashSpeed;
        dashTimer = 0.0f;

        if (this.dashDir.magnitude >= 0.1f)
        {
            this.StartCoroutine(this.DashRoutine(dashDir.normalized));
        }
    }

    IEnumerator DashRoutine(Vector3 dashDir)
    {
        if(this.dashDist <= 0.0001f)
            yield break;

        if (this.dashDuration <= 0.01f)
        {
            this.transform.position += dashDir * this.dashDist * Time.deltaTime;
            //rb.MovePosition(transform.position + dashDir * this.dashDist * Time.fixedDeltaTime);
            yield break;
        }

        this.dashing = true;
        float timeElapsed = 0f;
        Vector3 start = transform.position;
        Vector3 target = this.transform.position + this.dashDist * dashDir;

        while(timeElapsed < this.dashDuration)
        {
            Vector3 iterTarget = Vector3.Lerp(start, target, timeElapsed / this.dashDuration);
            this.transform.position = iterTarget;
            attack();

            yield return null;
            timeElapsed += Time.deltaTime;
        }

        this.transform.position = target;
        this.dashing = false;
    }

    void attack()
    {
        Collider[] hitEnemiesSide = Physics.OverlapSphere(attackPoints[GetComponent<CharChanging>().getActiveAttackPoint()].position, attackRange, enemyLayers);

        //damage enemies
        foreach (Collider enemy in hitEnemiesSide)
        {
            Debug.Log("Side: Hit " + enemy.name);
            enemy.GetComponent<EnemyController>().TakeDamage(attackDamage);
        }
    }
}
