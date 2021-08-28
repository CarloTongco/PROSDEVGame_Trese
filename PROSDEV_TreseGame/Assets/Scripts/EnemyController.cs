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
    private Vector3 areaOffset = new Vector3(0,1,0);
    private Vector3 areaDetector;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        areaDetector = area.transform.position + areaOffset;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
        currentHealth = maxHealth;
        cubeRenderer = GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, areaDetector);
        float playerDistance = Vector3.Distance(target.position, transform.position);

        if (distance <= 7.5)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(startingPosition);

        Debug.Log(playerDistance);

        if(playerDistance <= 1.25)
        {
            attackDelay -= Time.deltaTime;
            if(attackDelay <= 0.0f)
            {
                AttackPlayer(attackDamage);
            }
        }
    }

    public void AttackPlayer(int damage)
    {
        //Play attack anim

        Debug.Log("Enemy is attacking the player! Player is taking " + damage + " damage.");
        player.PlayerTakeDamage(damage); //Reduce player health
        attackDelay = attackCooldown;


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

        //Destroy Enemy Game Object
        
    }

    private void OnDrawGizmosSelected()
    {
        areaOffset = new Vector3(0, 1, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(area.transform.position+areaOffset, area.transform.localScale);
    }
}
