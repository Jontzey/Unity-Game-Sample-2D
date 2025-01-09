using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Npc_Information : MonoBehaviour
{
    
    [Header("Npc Information")]
    [SerializeField] public string Npc_name;
    [SerializeField] public bool isQuestAvailable;
    
    public Quest QuestToGive;
    private void Awake() {
       
        
    }
    void Start()
    {
        isQuestAvailable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public void UpdateQuestAvailability(){
        isQuestAvailable = false;
        GiveQuest();
    }


    public void GiveQuest()
    {
        if (QuestToGive != null && !QuestToGive.Completed)
        {
            // Hämta QuestManager i scenen och lägg till questen
            QuestManagerScript questManager = FindObjectOfType<QuestManagerScript>();
            if (questManager != null)
            {
                questManager.AddQuest(QuestToGive);
                Debug.Log($"Quest '{QuestToGive.QuestName}' har getts till spelaren!");
            }
            else
            {
                Debug.LogError("Ingen QuestManager hittades i scenen!");
            }
        }
        else
        {
            Debug.Log("Ingen quest att ge ut eller questen är redan klar!");
        }
    }
}
