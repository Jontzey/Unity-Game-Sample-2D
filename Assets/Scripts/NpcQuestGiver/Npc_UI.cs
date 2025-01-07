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

    public QuestManager questManager;
    private bool InNpcRange = false;
    void Awake(){
       Npc_Ui_text = transform.Find("NpcCanvas/NpcName").GetComponent<TextMeshProUGUI>();
       Npc_isQuestAvailable = transform.Find("NpcCanvas/NpcQuestAvailable").GetComponent<TextMeshProUGUI>();


       GameObject WorldCanvas = GameObject.Find("WorldCanvas");

       questManager = WorldCanvas.GetComponent<QuestManager>();
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
                    questManager.OpenQuestMenu();
                    //  npc_Information.UpdateQuestAvailability();
                    //  QuestAccepted();
            }
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
             Npc_isQuestAvailable.gameObject.SetActive(false);
    }
}
