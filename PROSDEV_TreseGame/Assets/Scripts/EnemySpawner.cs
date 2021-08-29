using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemies;
    public GameObject currArea;

    private Vector3 spawnPos;
    private int enemyCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<EnemyController>().setArea(currArea);
    }

    public void startSpawning()
    {
        //StartCoroutine(enemySpawn());
        while(enemyCount <= maxEnemies)
        {
            spawnPos = new Vector3(Random.Range(currArea.transform.position.x - 7.5f, currArea.transform.position.x + 7.5f), 0, Random.Range(currArea.transform.position.z - 7.5f, currArea.transform.position.z + 7.5f));
            Instantiate(enemy, spawnPos, Quaternion.identity).GetComponent<EnemyController>().setArea(currArea);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().addEnemy();
            enemyCount++;
        }
    }

    IEnumerator enemySpawn()
    {
        while(enemyCount <= maxEnemies)
        {
            spawnPos = new Vector3(Random.Range(currArea.transform.position.x - 7.5f, currArea.transform.position.x + 7.5f), 0, Random.Range(currArea.transform.position.z - 7.5f, currArea.transform.position.z + 7.5f));
            Instantiate(enemy, spawnPos, Quaternion.identity).GetComponent<EnemyController>().setArea(currArea);
            yield return new WaitForSeconds(0.0001f);
            enemyCount += 1;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().addEnemy();
        }
    }
}
