using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string ItemCollectedSentence;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioSource audioSource;
    

    [SerializeField] public int QuestId;
    [SerializeField] public string NpcNameRelation;

    [SerializeField] UserInterfaceManager userInterfaceManager;
    private void Awake() {
        userInterfaceManager = FindAnyObjectByType<UserInterfaceManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            userInterfaceManager.npcInformation = GameObject.Find(NpcNameRelation).GetComponent<NpcInformation>();
            var allQuests = QuestManager.instance.quests;

            if(allQuests != null){

                foreach(Quest quests in allQuests){
                    if(QuestId == quests.Questid){
                        quests.UpdateProgress(1);
                        userInterfaceManager.AddTextMessage(ItemCollectedSentence);
                        
                         audioSource.PlayOneShot(pickupSound);
                        
                        Destroy(gameObject,pickupSound.length);
                    }
                }
            }
        }
    }
}
