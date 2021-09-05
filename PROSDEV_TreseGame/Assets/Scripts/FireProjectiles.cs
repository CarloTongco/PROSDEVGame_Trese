using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    //public LayerMask selectLayers;
    public LayerMask ignoreLayers;
    private Ray ray;
    private RaycastHit hit;

    public float nextFireTime;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        //plane = new Plane(Vector3.up, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            fire();
        //if (Time.time >= nextFireTime)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        fire();
        //        nextFireTime = (Time.time + 1f) / cooldown;
        //    }
        //}
    }

    public void fire()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignoreLayers))
        {
            Vector3 mousePos = hit.point + new Vector3(0, 0.5f, 0);
            //Debug.Log(rayDir);
            GameObject projectile = ProjectilePool.projectilePoolInstance.getProjectile();
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<RangedAttackProjectile>().setMoveDirection(mousePos - transform.position);

            //if (hit.collider.CompareTag("Enemy"))
            //    Debug.Log("enemy damaged");

            //Debug.Log(hit.point);

            //Debug.DrawRay(transform.position, mousePos - transform.position, Color.yellow, 10f);
            //Debug.Log("Hit");
        }
    }
}
