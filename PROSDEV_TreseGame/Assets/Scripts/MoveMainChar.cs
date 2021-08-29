using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMainChar : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;
    private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.z = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
            MoveCharacter();
    }

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * moveSpeed * Time.fixedDeltaTime);
    }
}
