using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int attackDamage = 5;
    private float attackDelay = 0.0f;
    private float attackCooldown = 5.0f;
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    private Transform target;
    private NavMeshAgent agent;
    private Renderer cubeRenderer;
    public PlayerHealth player;

    public GameObject area;
    public GameObject healthPickup;

    private Vector3 areaOffset = new Vector3(0,1,0);
    private Vector3 areaDetector;
    private Vector3 startingPosition;
    private Texture currTexture;

    // Start is called before the first frame update
    void Start()
    {
        //areaDetector = area.transform.position + areaOffset;
        player = GameObject.Find("MC").GetComponent<PlayerHealth>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
        currentHealth = maxHealth;
        cubeRenderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, areaDetector);
        float playerDistance = Vector3.Distance(target.position, transform.position);

        if (distance <= 10)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(startingPosition);

        //Debug.Log(playerDistance);

        if(playerDistance <= 1.35)
        {
            this.attackDelay -= Time.deltaTime;
            if(this.attackDelay <= 0.0f)
            {
                this.AttackPlayer(attackDamage);
            }
        }
    }

    public void AttackPlayer(int damage)
    {
        //Play attack anim

        //Debug.Log("Enemy is attacking the player! Player is taking " + damage + " damage.");
        player.PlayerTakeDamage(damage); //Reduce player health
        attackDelay = attackCooldown;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Projectile"))
            Debug.Log("Collided");
            TakeDamage(40);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        cubeRenderer.material.SetColor("_Color", Color.red);
        agent.isStopped = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().removeEnemy();

        float random = Random.Range(0f, 4f);
        Debug.Log(random);

        //spawn health pickup
        if (random <= 1f)
            {
                Instantiate(healthPickup, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                Debug.Log("spawn health");
            }
        
        //Destroy Enemy Game Object
        Destroy(gameObject);

    }

    public void setArea(GameObject assignedArea)
    {
        areaDetector = assignedArea.transform.position + areaOffset;
    }

    private void OnDrawGizmosSelected()
    {
        areaOffset = new Vector3(0, 1, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(area.transform.position+areaOffset, area.transform.localScale);
    }
}
