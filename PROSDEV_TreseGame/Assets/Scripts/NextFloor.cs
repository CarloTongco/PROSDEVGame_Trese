using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloor : MonoBehaviour
{
    public int dungeonNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            teleportToNextFloor();
    }

    private void teleportToNextFloor()
    {
        SceneManager.LoadScene("Dungeon " + dungeonNum, LoadSceneMode.Single);
    }
}
