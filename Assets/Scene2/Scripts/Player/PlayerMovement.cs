using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject UnitRoot;
    Animator anim;
    [SerializeField] private float PlayerSpeed = 2.5f;

    [SerializeField] private AudioSource walkingAudioSource;
    void Start()
    {
        UnitRoot = GameObject.Find("Player/UnitRoot");
        anim = UnitRoot.GetComponent<Animator>();
        walkingAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
            transform.localScale = new Vector3(-1, 1, 1); // Flip sprite for right movement
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            transform.localScale = new Vector3(1, 1, 1); // Flip sprite for left movement
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
        }

        // Apply movement
        transform.position += movement.normalized * Time.deltaTime * PlayerSpeed;

        // Update animation
        bool isMoving = movement != Vector3.zero;
        anim.SetBool("1_Move", isMoving);
        if (isMoving)
    {
        if (!walkingAudioSource.isPlaying)
        {
            walkingAudioSource.Play(); // Start playing the walking sound
        }
    }
    else
    {
        if (walkingAudioSource.isPlaying)
        {
            walkingAudioSource.Stop(); // Stop the walking sound when the player stops moving
        }
    }
    if (Input.GetKeyUp(KeyCode.Mouse0))
    {
        anim.SetBool("2_Attack",true);
    }
    }
    
}
