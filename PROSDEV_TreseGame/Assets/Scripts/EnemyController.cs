using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    public GameObject area;
    public GameObject enemy;
    private Vector3 areaOffset = new Vector3(0,1,0);
    private Vector3 areaDetector;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        areaDetector = area.transform.position + areaOffset;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        startingPosition = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, areaDetector);

        if (distance <= 7.5)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(startingPosition);
        
    }

    private void OnDrawGizmosSelected()
    {
        areaOffset = new Vector3(0, 1, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(area.transform.position+areaOffset, area.transform.localScale);
    }
}
