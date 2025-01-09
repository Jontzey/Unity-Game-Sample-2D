using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    Animator anim;
    PlayerStats playerStats;
    void Start()
    {
         anim = GetComponent<Animator>();
         playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.playerIsDead == false){
            if(Input.GetKeyUp(KeyCode.Mouse0)){
                anim.SetBool("2_Attack", true);
            }
        }
    }

   public void TurnCharacter(float moveX){

        transform.localScale = new Vector3(-Mathf.Sign(moveX), 1, 1);
        
    }

    public void IsMoving(bool isMoving){
        if(isMoving){

          anim.SetBool("1_Move", true);
        }
        else{

          anim.SetBool("1_Move", false);
          }
    }
}
