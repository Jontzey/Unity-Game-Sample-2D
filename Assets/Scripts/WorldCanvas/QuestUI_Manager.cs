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



    private GameObject npcQuestGiver;
    private Npc_Information Npc_Information;
    private Quest quest;

    private void Awake() {
        // hitta objektet i child från parent
        Transform questNameTransform = transform.Find("QuestName");
        Transform questDescriptionTransform = transform.Find("QuestDescription");
        Transform questGoalTransform = transform.Find("QuestGoal");
        // hämta komponent
        TextMeshProUGUI questNameText = questNameTransform.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI quesDescriptionText = questNameTransform.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI questGoalText = questNameTransform.GetComponent<TextMeshProUGUI>();

        questNameText.text = quest.QuestName;
        quesDescriptionText.text = quest.Description;

        npcQuestGiver = GameObject.Find("NpcQuestGiver");
        Npc_Information = npcQuestGiver.transform.Find("UnitRoot").GetComponent<Npc_Information>();

    }
    private void Start()
    {
        // questMenu = transform.Find("QuestMenu").GetComponent<GameObject>();

       
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
