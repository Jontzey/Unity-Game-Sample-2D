using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string ItemCollectedSentence;
    [SerializeField] private AudioClip pickupSound;
    private AudioSource audioSource;
    

    [SerializeField] public int QuestId;

    [SerializeField] UserInterfaceManager userInterfaceManager;
    private void Awake() {
        userInterfaceManager = FindAnyObjectByType<UserInterfaceManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            
            var allQuests = QuestManager.instance.quests;

            if(allQuests != null){

                foreach(Quest quests in allQuests){
                    if(QuestId == quests.Questid){
                        quests.UpdateProgress(1);
                        userInterfaceManager.AddTextMessage(ItemCollectedSentence);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
