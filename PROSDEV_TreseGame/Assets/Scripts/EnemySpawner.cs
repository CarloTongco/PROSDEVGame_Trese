using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemies;
    public GameObject currArea;


    private Material[] enemyMaterials;
    private Vector3 spawnPos;
    private int enemyCount = 1;
    private Material currMaterial;

    // Start is called before the first frame update
    void Start()
    {
        enemyMaterials = GameObject.FindGameObjectWithTag("GameController").GetComponent<MaterialManager>().materials;
        enemy.GetComponent<EnemyController>().setArea(currArea);
    }

    public void startSpawning()
    {
        int enemyMaterial;

        //StartCoroutine(enemySpawn());
        while(enemyCount <= maxEnemies)
        {
            enemyMaterial = Random.Range(0, enemyMaterials.Length);

            currMaterial = enemyMaterials[enemyMaterial];

            enemy.GetComponentInChildren<Renderer>().material = currMaterial;

            spawnPos = new Vector3(Random.Range(currArea.transform.position.x - 7.5f, currArea.transform.position.x + 7.5f), 0, Random.Range(currArea.transform.position.z - 7.5f, currArea.transform.position.z + 7.5f));
            GameObject clone = Instantiate(enemy, spawnPos, Quaternion.identity);
            clone.GetComponent<EnemyController>().setArea(currArea);
            clone.GetComponentInChildren<Renderer>().material = currMaterial;

            GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().addEnemy();
            enemyCount++;
        }
    }

    //IEnumerator enemySpawn()
    //{
    //    while(enemyCount <= maxEnemies)
    //    {
    //        spawnPos = new Vector3(Random.Range(currArea.transform.position.x - 7.5f, currArea.transform.position.x + 7.5f), 0, Random.Range(currArea.transform.position.z - 7.5f, currArea.transform.position.z + 7.5f));
    //        Instantiate(enemy, spawnPos, Quaternion.identity).GetComponent<EnemyController>().setArea(currArea);
    //        yield return new WaitForSeconds(0.0001f);
    //        enemyCount += 1;
    //        GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyCounter>().addEnemy();
    //    }
    //}
}
