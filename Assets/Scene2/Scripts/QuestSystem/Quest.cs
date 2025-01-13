using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    // Start is called before the first frame update
    [SerializeField] public int Questid;
    [SerializeField] public string QuestName;
    [SerializeField] public string QuestGoalDescription;
    [SerializeField] public string Description;

    [SerializeField] public int CurrentAmount;
    [SerializeField] public int RequiredAmount;

    [SerializeField] public int ExperienceReward;

    [SerializeField] public bool QuestComplete;
    [SerializeField] public bool IsQuestActive;
    void Start()
    {
        
    }

    // Update is called once per frame
     public void UpdateProgress(int amount)
    {
        CurrentAmount += amount;
        CheckQuestProgress();
    }

    public void CheckQuestProgress()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Debug.Log($"Quest Complete: {QuestName}");
            QuestComplete = true;
            // QuestManager.instance.RemoveQuest(this);
        }
        else
        {
            Debug.Log($"{QuestName} Progress: {CurrentAmount}/{RequiredAmount}");
        }
    }
}
