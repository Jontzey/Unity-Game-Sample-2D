using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Quest_holder : MonoBehaviour
{
    public Quest QuestToGive; // Den quest som NPC ger ut
    private bool playerInRange = false; // Håller koll på om spelaren är nära

    private void Update()
    {
        // Om spelaren är nära och trycker på "E" (eller annan knapp) så ges questen
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            GiveQuest();
        }
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
