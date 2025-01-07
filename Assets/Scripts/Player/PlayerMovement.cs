using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    public PlayerSprite playerSprite;
    void Start()
    {
       Transform unitRootTransform = transform.Find("UnitRoot");
        playerSprite = unitRootTransform.GetComponent<PlayerSprite>();
    }

    // Update is called once per frame
    void Update()
    {
           // Get input for horizontal and vertical movement
            float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right keys
            float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down keys

            // Combine inputs into a direction vector
            Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;

            // Move the character
            transform.position += moveDirection * Time.deltaTime * 3;
            
            // Update animation state
            if (moveDirection != Vector3.zero)
            {
                

                // Flip character horizontally based on movement direction
                if (moveX != 0){
                    playerSprite.TurnCharacter(moveX);
                    playerSprite.IsMoving(true);
                }
                    // transform.localScale = new Vector3(-Mathf.Sign(moveX), 1, 1);
            }
            else
            {
                 playerSprite.IsMoving(false);
   
            }
    }
}
