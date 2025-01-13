using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollider : MonoBehaviour
{
   [SerializeField] NpcInformation npcInformation;
   [SerializeField] UserInterfaceManager userInterfaceManager;
    private void Start() {
        npcInformation = GetComponent<NpcInformation>();
        userInterfaceManager = FindAnyObjectByType<UserInterfaceManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            npcInformation.IsPlayerInRange = true;
            if(npcInformation.IsNpcInteractable == true){
                userInterfaceManager.IsInteractAble(true, npcInformation);
            }else{
                userInterfaceManager.IsInteractAble(false,npcInformation);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            npcInformation.IsPlayerInRange = false;
             userInterfaceManager.IsInteractAble(false,npcInformation);
             userInterfaceManager.CloseQuestMenu();
        }
    }
}
