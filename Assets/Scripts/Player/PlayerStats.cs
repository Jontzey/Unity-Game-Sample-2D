using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float playerHealth = 100;
    [SerializeField] public string playerName = "Emil";
    [SerializeField] public bool playerIsDead = false;

    [SerializeField] public int level;

    [Header("PlayerUI")]
    public GameObject playerUI;
    public Slider playerHpBar;
    Animator anim;

    GameObject WorldCanvas;
    GameObject PlayerStatsUI;
    
   [SerializeField] private bool isPlayerStatsUiActive;

    void Awake(){
        WorldCanvas = GameObject.Find("WorldCanvas");
        PlayerStatsUI = WorldCanvas.transform.Find("PlayerStatsUI").gameObject;

    }
    void Start()
    {
        // playerHpBar = playerUI.gameObject.GetComponent<Slider>();
        playerHpBar.value = playerHealth;
        anim = transform.GetComponent<Animator>();
        if( level == 0){
            level = 1;
        }
        // ShowPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            ShowPlayerStats();
        }
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

    private void ShowPlayerStats(){
        
            if (!isPlayerStatsUiActive) // Om UI är inaktivt
            {
                PlayerStatsUI.SetActive(true);
                isPlayerStatsUiActive = true;
            }
            else // Om UI redan är aktivt
            {
                PlayerStatsUI.SetActive(false);
                isPlayerStatsUiActive = false;
            }

    }
}
