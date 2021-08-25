using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
        isCollided = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        isCollided = false;
    }

    public bool getIsCollided()
    {
        return this.isCollided;
    }
}
