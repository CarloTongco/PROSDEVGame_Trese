using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private int aliveEnemies = 0;

    public void addEnemy()
    {
        aliveEnemies++;
        Debug.Log(aliveEnemies);
    }

    public void removeEnemy()
    {
        aliveEnemies--;
        Debug.Log(aliveEnemies);
    }

    public int getAliveEnemiesNum()
    {
        return aliveEnemies;
    }
}
