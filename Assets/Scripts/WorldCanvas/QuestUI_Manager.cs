using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestUI_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject questMenu;
    private bool isQuestMenuOpen;

    // [SerializeField] GameObject QuestName;
    // [SerializeField] GameObject QuestDescription;
    //  [SerializeField] GameObject QuestGoal;



    [SerializeField] private GameObject npcQuestGiver;
    [SerializeField] private Npc_Information Npc_Information;
   [SerializeField]  private Quest quest;
    [SerializeField] Transform questNameTransform;
   [SerializeField]  Transform questDescriptionTransform;
    [SerializeField] Transform questGoalTransform;
    [SerializeField]  TextMeshProUGUI questNameText;
      [SerializeField]   TextMeshProUGUI quesDescriptionText;
      [SerializeField]   TextMeshProUGUI questGoalText;
    private void Awake() {
        // hitta objektet i child från parent
        questNameTransform = transform.Find("QuestName");
        questDescriptionTransform = transform.Find("QuestDescription");
        questGoalTransform = transform.Find("QuestGoal");
        // hämta komponent
        questNameText = questNameTransform.GetComponent<TextMeshProUGUI>();
        quesDescriptionText = questNameTransform.GetComponent<TextMeshProUGUI>();
        questGoalText = questNameTransform.GetComponent<TextMeshProUGUI>();

        

        npcQuestGiver = GameObject.Find("NpcQuestGiver");
        Npc_Information = npcQuestGiver.transform.Find("UnitRoot").GetComponent<Npc_Information>();

    }
    private void Start()
    {
      

       
        isQuestMenuOpen = false;
    }
    // Update is called once per frame
   private void Update()
    {
        
    }


   public void OpenQuestMenu(){
        if(isQuestMenuOpen){
            transform.gameObject.SetActive(false);
            isQuestMenuOpen = false;
            
        }else{
            // questNameText.text = quest.QuestName;
            // quesDescriptionText.text = quest.Description;
            transform.gameObject.SetActive(true);
            isQuestMenuOpen = true;
        }
    }


    public void DeclineQuest(){
        Debug.Log("Declined Quest");
        transform.gameObject.SetActive(false);
        isQuestMenuOpen = false;
    }
 
    public void AcceptedQuest(){
        Debug.Log("Accepted Quest");
        transform.gameObject.SetActive(false);
        isQuestMenuOpen = false;
        Npc_Information.UpdateQuestAvailability();
    }
}
