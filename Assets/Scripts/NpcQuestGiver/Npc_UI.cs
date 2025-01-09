using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Npc_UI : MonoBehaviour
{
    // Start is called before the first frame update

    Npc_Information npc_Information;
    [SerializeField] public TextMeshProUGUI Npc_Ui_text;
    [SerializeField] public TextMeshProUGUI Npc_isQuestAvailable;

    private bool InNpcRange = false;

    public QuestUI_Manager QuestUI_Manager;
    private GameObject WorldCanvas;
    void Awake(){
       Npc_Ui_text = transform.Find("NpcCanvas/NpcName").GetComponent<TextMeshProUGUI>();
       Npc_isQuestAvailable = transform.Find("NpcCanvas/NpcQuestAvailable").GetComponent<TextMeshProUGUI>();

        WorldCanvas = GameObject.Find("WorldCanvas");
        GameObject questMenu = WorldCanvas.transform.Find("QuestMenu").gameObject;
        QuestUI_Manager = questMenu.GetComponent<QuestUI_Manager>();

    //    GameObject WorldCanvas = GameObject.Find("WorldCanvas");

    //    questManager = WorldCanvas.GetComponent<QuestManager>();
    }
    void Start()
    {
        npc_Information = GetComponent<Npc_Information>();
        Npc_Ui_text.text = npc_Information.Npc_name;

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.E)){
            if(npc_Information.isQuestAvailable == true && InNpcRange == true){
                    QuestUI_Manager.OpenQuestMenu();
                    //  npc_Information.UpdateQuestAvailability();
                    //  QuestAccepted();
            }
       }
        if(npc_Information.QuestToGive.Completed){
            UpdateUiCompleted();
        }
    }


    public void IsWithinQuestArea(bool IsInArea){
        if(IsInArea && npc_Information.isQuestAvailable == true){
            InNpcRange = IsInArea;

        }else if(!IsInArea){
            InNpcRange = IsInArea;
        }
    }

    public void QuestAccepted(){
            //  Npc_isQuestAvailable.gameObject.SetActive(false);
            Npc_isQuestAvailable.text = "?";
            Npc_isQuestAvailable.fontStyle = FontStyles.Bold;
            Npc_isQuestAvailable.color = Color.grey;
    }

    public void UpdateUiCompleted(){
        Npc_isQuestAvailable.color = Color.yellow;
        
    }
}
