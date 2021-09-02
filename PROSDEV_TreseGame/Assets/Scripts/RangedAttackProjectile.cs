using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackProjectile : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void setMoveDirection(Vector3 dir)
    {
        moveDirection = new Vector3(dir.x, 0, dir.z);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}