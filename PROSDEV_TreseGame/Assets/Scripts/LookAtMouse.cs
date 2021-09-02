using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Texture[] classes;
    private Vector3 initScale;
    private Vector3 changeDir = new Vector3(-1, 1, 1);
    private Transform gfxScale;
    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        gfxScale = GameObject.Find("MainCharGFX").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 90f && angle > -90)
        {
            //Debug.Log("Right side of screen");
            gfxScale.localScale = new Vector3(-0.2f, 1f, -0.2f);
        }
        else
        {
//Debug.Log("Left side of screen");
            gfxScale.localScale = new Vector3(0.2f, 1f, -0.2f);
        }
    }
}
