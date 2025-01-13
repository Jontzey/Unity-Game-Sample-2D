using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcCanvasUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] NpcInformation npcInformation;

    [SerializeField] GameObject NpcCanvas;

    [SerializeField] TextMeshProUGUI QuestStatus;

    private void Awake() {
        npcInformation = GetComponent<NpcInformation>();
        NpcCanvas = transform.Find("NpcCanvas").gameObject;

        QuestStatus = NpcCanvas.transform.Find("QuestStatus").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        if(npcInformation.quest.IsQuestActive != true){
            QuestStatus.text = "!";
        }
    }

   public void UpdateQuestStatusUI(){
        if(npcInformation.quest.QuestComplete){
            QuestStatus.text = "?";
            QuestStatus.color = Color.yellow;
            if(npcInformation.quest.QuestComplete && npcInformation.quest.IsQuestActive == false){
                QuestStatus.text = "";
            }
        }else{
            if(!npcInformation.quest.IsQuestActive){
               QuestStatus.text = "!";
                QuestStatus.color = Color.yellow;
            }else{
                
                QuestStatus.text = "?";
                QuestStatus.color = Color.grey;
            }

        }
    }
}
