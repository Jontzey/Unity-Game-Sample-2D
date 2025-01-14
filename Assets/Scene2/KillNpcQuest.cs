using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class KillNpcQuest : MonoBehaviour
{
    [SerializeField] float Health = 30;
    [SerializeField] bool IsDead = false;
    [SerializeField] string KilledSentence;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField] public GameObject PrefabSkeleton;
    [SerializeField] public int QuestId;
    [SerializeField] public string NpcNameRelation;

    [SerializeField] UserInterfaceManager userInterfaceManager;
    private void Awake() {
        userInterfaceManager = FindAnyObjectByType<UserInterfaceManager>();
        // audioSource = GetComponent<AudioSource>();
        Health = 30;
        IsDead = false;
    }


    private void UpdateQuest(){
          var allQuests = QuestManager.instance.quests;

            if(allQuests != null){

                foreach(Quest quests in allQuests){
                    if(QuestId == quests.Questid){
                        quests.UpdateProgress(1);
                        userInterfaceManager.AddTextMessage(KilledSentence);
                        
                        //  audioSource.PlayOneShot(pickupSound);
                        
                        // Destroy(gameObject);
                    }
                }
            }
    }

    private IEnumerator DestroyGameObject(){
         // Store the position and rotation of the current object
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            // Wait for 4 seconds before deactivating the object
            yield return new WaitForSeconds(4);
            transform.Find("UnitRoot").gameObject.SetActive(false); // Deactivate the current object

            // Wait another 4 seconds before spawning the new prefab
            yield return new WaitForSeconds(4);
            var NewSkelly = Instantiate(PrefabSkeleton, position, rotation); // Spawn the new prefab
            NewSkelly.transform.Find("UnitRoot").gameObject.SetActive(true);

            // Optionally destroy the original object after a delay (if needed)
            yield return new WaitForSeconds(1);
            Destroy(gameObject); // Completely remove the original object (optional)
    }
    private void PlayDeathAnimation(){
       Animator anim = transform.Find("UnitRoot").gameObject.GetComponent<Animator>();
       anim.SetBool("4_Death",true);
       anim.SetBool("isDeath", true);
       StartCoroutine(DestroyGameObject());
    }
     private void Die(){
        UpdateQuest();
        PlayDeathAnimation();
     }
    private void TakeDamage(float Dmg){
        if(Health >= 0){
            Health -= Dmg;
            if(Health <= 0){
                IsDead = true;
            Die();
            }
        }else{
            IsDead = true;
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Sword"){
            userInterfaceManager.npcInformation = GameObject.Find(NpcNameRelation).GetComponent<NpcInformation>();

            if(!IsDead){
                TakeDamage(10);
            }else{
                Die();
            }
            // var allQuests = QuestManager.instance.quests;

            // if(allQuests != null){

            //     foreach(Quest quests in allQuests){
            //         if(QuestId == quests.Questid){
            //             quests.UpdateProgress(1);
            //             userInterfaceManager.AddTextMessage(KilledSentence);
                        
            //             //  audioSource.PlayOneShot(pickupSound);
                        
            //             Destroy(gameObject);
            //         }
            //     }
            // }
        }
    }
}
