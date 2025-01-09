using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderTestDamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerObject;
    
    private PlayerStats playerStats;

     public float damageInterval = 1.0f; // Time between each damage tick
    public int damageAmount = 1; // Damage per tick
    private bool isPlayerInTrigger = false; // To track if the player is in the trigger
    private Coroutine damageCoroutine; 
    void Start()
    {

        playerStats = PlayerObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isPlayerInTrigger)
            {
                isPlayerInTrigger = true;
                damageCoroutine = StartCoroutine(TickDamage());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isPlayerInTrigger)
            {
                isPlayerInTrigger = false;
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine);
                    damageCoroutine = null;
                }
            }
        }
    }

    private IEnumerator TickDamage()
    {
        while (isPlayerInTrigger)
        {
            if (playerStats != null)
            {
                playerStats.TakeDamage(damageAmount);
            }
            yield return new WaitForSeconds(damageInterval); // Wait before the next tick
        }
    }
}
