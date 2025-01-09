using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class Quest
{
 public string QuestName;
    public string Description;
    public List<QuestGoal> Goals;
    public int ExperienceReward;
    // public Item ItemReward;
    public bool Completed;

    public void CheckGoals()
    {
        Completed = Goals.TrueForAll(goal => goal.Completed);
        if (Completed)
        {
            Debug.Log("Quest Completed!");
            // GiveReward();
        }
    }

    // public void GiveReward()
    // {
    //     if (ItemReward != null)
    //     {
    //         // Code to add item to inventory
    //         Debug.Log($"Player received item: {ItemReward.name}");
    //     }

    //     // Add experience to player
    //     Debug.Log($"Player gained {ExperienceReward} experience.");
    // }
}
