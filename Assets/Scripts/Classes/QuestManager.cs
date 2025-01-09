using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManagerScript : MonoBehaviour
{
    public QuestManagerScript Instance;
  public List<Quest> ActiveQuests = new List<Quest>();

  public GameObject questUIParent; // GameObject med Vertical Layout Group
    public GameObject questUIPrefab; // Prefab för varje quest
    private Dictionary<Quest, GameObject> activeQuestUIItems = new Dictionary<Quest, GameObject>();

    private void Awake() {
        Instance = this;
    }
    public void AddQuest(Quest quest)
    {
         if (activeQuestUIItems.ContainsKey(quest))
        {
            Debug.LogWarning($"Quest '{quest.QuestName}' already exists in the UI.");
            return;
        }
        // Skapa en ny UI-instans för questen
        GameObject questUIItem = Instantiate(questUIPrefab, questUIParent.transform);
        // questUIItem.GetComponentInChildren<TextMeshProUGUI>().text = $"{quest.Description}\n";

        foreach (QuestGoal goal in quest.Goals)
        {
            questUIItem.GetComponentInChildren<TextMeshProUGUI>().text = $"{goal.GoalDescription}: {goal.CurrentAmount}/{goal.RequiredAmount}\n";
        }
         ActiveQuests.Add(quest);

        // Lägg till quest och dess UI i dictionary
        activeQuestUIItems.Add(quest, questUIItem);
        Debug.Log($"Quest '{quest.QuestName}' added!");
    }

    public void RemoveQuest(Quest quest)
    {
          if (activeQuestUIItems.TryGetValue(quest, out GameObject questUIItem))
        {
            // Ta bort UI-objektet
            Destroy(questUIItem); 
            activeQuestUIItems.Remove(quest);
        }
        else
        {
            Debug.LogWarning($"Quest '{quest.QuestName}' not found in the UI.");
        }
        ActiveQuests.Remove(quest);
        Debug.Log($"Quest '{quest.QuestName}' removed!");
    }

    public void CheckAllQuests()
    {
        foreach (var quest in ActiveQuests)
        {
            quest.CheckGoals();
        }
    }
    public void UpdateQuest(Quest quest)
    {
        if (activeQuestUIItems.TryGetValue(quest, out GameObject questUIItem))
        {
            string questText = $"{quest.Description}\n";
            foreach (QuestGoal goal in quest.Goals)
            {
                if(!goal.Completed){
                    questText = $"{goal.GoalDescription}: {goal.CurrentAmount}/{goal.RequiredAmount}\n";
                }else{
                    questText = $"{goal.GoalDescription}: {goal.CurrentAmount}/{goal.RequiredAmount}: Completed";
                }
            }

            questUIItem.GetComponentInChildren<TextMeshProUGUI>().text = questText;
        }else{
            Debug.Log("No quest ui found");
        }
    }
}
