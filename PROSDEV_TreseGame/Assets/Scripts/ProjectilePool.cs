using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool projectilePoolInstance;

    public int amountToPool;

    [SerializeField]
    private GameObject pooledProjectile;
    private bool isPoolEmpty = true;

    private List<GameObject> projectiles;

    private void Awake()
    {
        projectilePoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        projectiles = new List<GameObject>();
        GameObject tmp;
        for(int i=0; i < amountToPool; i++)
        {
            tmp = Instantiate(pooledProjectile);
            tmp.SetActive(false);
            projectiles.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getProjectile()
    {
        for(int i=0; i<amountToPool; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return projectiles[i];
        }

        return null;
    }
}
