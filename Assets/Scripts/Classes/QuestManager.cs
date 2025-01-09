using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManagerScript : MonoBehaviour
{
  public List<Quest> ActiveQuests = new List<Quest>();

    public void AddQuest(Quest quest)
    {
        ActiveQuests.Add(quest);
        Debug.Log($"Quest '{quest.QuestName}' added!");
    }

    public void RemoveQuest(Quest quest)
    {
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
}
