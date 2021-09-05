using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill : MonoBehaviour
{
    public float nextVolleyTime;
    public float cooldown;

    private int bulletsAmount = 3;

    private float startAngle = 90f;
    private float endAngle = 270f;

    private Vector3 bulletMoveDir;

    Ray ray;
    RaycastHit hit;

    public LayerMask ignorLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextVolleyTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                volley();
                nextVolleyTime = (Time.time + 1f) / cooldown;
            }
        }
    }

    void volley()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, ~ignorLayers))
        {
            Vector3 mousePos = hit.point;
            mousePos.y = transform.position.y;

            float angle = Mathf.Atan2(mousePos.z, mousePos.x) * Mathf.Rad2Deg;

            Vector3[] positions = { mousePos - transform.position + new Vector3(-1f, 0, 1f), mousePos - transform.position, mousePos - transform.position + new Vector3(1f, 0, -1f)};

            foreach(Vector3 position in positions)
            {
                GameObject projectile = ProjectilePool.projectilePoolInstance.getProjectile();
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true);
                projectile.GetComponent<RangedAttackProjectile>().setMoveDirection(position);
            }

            float projectileDirX = (mousePos.x - transform.position.x) + Mathf.Sin((startAngle * Mathf.PI) / 180f);
            float projectileDirZ = (mousePos.z - transform.position.z) + Mathf.Cos((startAngle * Mathf.PI) / 180f);

            //Vector3 offset = new Vector3(projectileDirX, 0, projectileDirZ);

            //Debug.DrawRay(transform.position, mousePos - transform.position + new Vector3(-1f, 0, 1f), Color.red, 10f);
            //Debug.DrawRay(transform.position, mousePos - transform.position, Color.red, 10f);
            //Debug.DrawRay(transform.position, mousePos - transform.position + new Vector3(1f, 0, -1f), Color.red, 10f);

            //Debug.Log("triggerred");

            //GameObject projectile = ProjectilePool.projectilePoolInstance.getProjectile();
            //GameObject projectile1 = ProjectilePool.projectilePoolInstance.getProjectile();
            //GameObject projectile2 = ProjectilePool.projectilePoolInstance.getProjectile();

            //projectile.transform.position = transform.position;
            //projectile.transform.rotation = transform.rotation;

            //projectile1.transform.position = transform.position;
            //projectile1.transform.rotation = transform.rotation;

            //projectile2.transform.position = transform.position;
            //projectile2.transform.rotation = transform.rotation;

            //projectile.SetActive(true);
            //projectile1.SetActive(true);
            //projectile2.SetActive(true);

            //projectile.GetComponent<RangedAttackProjectile>().setMoveDirection(mousePos - transform.position + new Vector3(-1f, 0, 1f));
            //projectile1.GetComponent<RangedAttackProjectile>().setMoveDirection(mousePos - transform.position);
            //projectile2.GetComponent<RangedAttackProjectile>().setMoveDirection(mousePos - transform.position + new Vector3(1f, 0, -1f));

            //float startAngle = mousePos.x;

            //mousePos.y = this.transform.position.y;
            //float dirX = transform.position.x + Mathf.Sin((angle))
        }
    }

}
