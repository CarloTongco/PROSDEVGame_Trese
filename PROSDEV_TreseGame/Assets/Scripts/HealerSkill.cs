using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSkill : MonoBehaviour
{
    public float nextHealTime;
    public float cooldown;

    private int healDuration = 0;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextHealTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(heal());
                nextHealTime = (Time.time + 1f) / cooldown;
            }
        }
    }

    IEnumerator heal()
    {
        int healDuration = 0;

        while(healDuration <= 5)
        {
            if (playerHealth.currentHealth < playerHealth.getMaxHealth())
            {
                playerHealth.healthSkill();
                healDuration++;
                yield return new WaitForSeconds(1);
            }
            else
                yield return null;
        }
    }
}
