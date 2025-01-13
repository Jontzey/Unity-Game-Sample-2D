using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using System.Linq;
public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    
    public List<Quest> quests;
    private void Awake() {
         instance = this;
    }

    public void AddQuest(Quest quest){
        quests.Add(quest);
    }

    public void RemoveQuest(Quest quest){
        quests.Remove(quest);
    }

     public void UpdateQuest(Quest quest)
    {
        quest.CheckQuestProgress();
    }
}
