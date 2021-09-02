using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    public LayerMask ignoreLayers;
    private Ray ray;
    private RaycastHit hit;
    private Plane plane;

    public int bulletsAmount = 1;

    private Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(Vector3.up, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            fire();
    }

    public void fire()
    {
        //Vector3 rayDir = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z+0.1f);
        float distance;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, ray.direction, out hit, 10, ~ignoreLayers))
        {
            //GameObject projectile = ProjectilePool.projectilePoolInstance.getProjectile();
            //projectile.transform.position = transform.position;
            //projectile.transform.rotation = transform.rotation;
            //projectile.SetActive(true);
            //projectile.GetComponent<RangedAttackProjectile>().setMoveDirection(hit.point);
            //Debug.Log(hit.point);

            Debug.DrawRay(transform.position, ray.GetPoint(hit), Color.yellow, 10f);
            Debug.Log("Hit");
        }
    }
}
