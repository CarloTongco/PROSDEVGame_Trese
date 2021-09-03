using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPortal : MonoBehaviour
{
    public GameObject teleporter;

    private Renderer renderer;
    private BoxCollider collider;
 

    // Start is called before the first frame update
    void Start()
    {
        renderer = teleporter.GetComponent<Renderer>();
        collider = teleporter.GetComponent<BoxCollider>();
        renderer.enabled = false;
        collider.enabled = false;
    }

    public void openPortal()
    {
        renderer.enabled = true;
        collider.enabled = true;
    }
}
