using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float playerHealth = 100;
    [SerializeField] public string playerName = "player_name";
    [SerializeField] public bool playerIsDead = false;


    [Header("PlayerUI")]
    public GameObject playerUI;
    public Slider playerHpBar;
    Animator anim;
    void Start()
    {
        // playerHpBar = playerUI.gameObject.GetComponent<Slider>();

        playerHpBar.value = playerHealth;
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float enemyDamage){
        if(playerIsDead == false){

            playerHealth -= enemyDamage;
            playerHpBar.value = playerHealth;
            if(playerHealth <= 0 && playerIsDead == false){
                PlayerDeath();
            }
            
        }
    }

    private void PlayerDeath(){
        playerIsDead = true;
        anim.SetBool("4_Death", true);
        anim.SetBool("isDeath", true);
    }
}
