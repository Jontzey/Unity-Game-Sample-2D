using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Collider : MonoBehaviour
{
    // Start is called before the first frame update
    Npc_Information npc_Information;
    Npc_UI npc_UI;
    void Start()
    {
        npc_Information = GetComponent<Npc_Information>();
        npc_UI = GetComponent<Npc_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
                Debug.Log("Is within Quest givers area");

                npc_UI.IsWithinQuestArea(true);
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
          if(other.gameObject.tag == "Player"){
            Debug.Log("Player left quest area");
            npc_UI.IsWithinQuestArea(false);
        }
    }
}
