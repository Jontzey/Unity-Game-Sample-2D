using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(-1,0,0) * Time.deltaTime * 3;
        }
         if(Input.GetKey(KeyCode.D)){
             transform.position += new Vector3(1,0,0)* Time.deltaTime * 3;
             transform.localScale = new Vector3(1, 1, 1);
        }
         if(Input.GetKey(KeyCode.W)){
              transform.position += new Vector3(0,1,0)* Time.deltaTime* 3;
        }
         if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(0,-1,0)* Time.deltaTime* 3;
        }
    }
}
