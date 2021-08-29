using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject spawner;
    public GameObject[] walls;

    private BoxCollider currBoxCollider;
    private EnemyCounter enemyCounter;
    private bool activated = false;
    private float delay = 0f;

    private void Start()
    {
        enemyCounter = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>();
        currBoxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        if(activated && delay >= 5)
            checkIfComplete();
        delay++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<BoxCollider>().enabled = true;
            }
            spawner.GetComponent<EnemySpawner>().startSpawning();
            activated = true;
        }
    }

    private void checkIfComplete()
    {
        if(enemyCounter.getAliveEnemiesNum() == 0)
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<BoxCollider>().enabled = false;
            }
            currBoxCollider.enabled = false;
        }
    }
}
