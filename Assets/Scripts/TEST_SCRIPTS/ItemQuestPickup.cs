using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ItemQuestPickup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject questManager;
    QuestManagerScript questManagerScript;
    public string GatherType;

    private void Start() {
        questManager = GameObject.Find("QuestManagerScript");
        questManagerScript = questManager.GetComponent<QuestManagerScript>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            foreach (Quest quest in questManagerScript.Instance.ActiveQuests)
            {
                foreach (QuestGoal goal in quest.Goals)
                {
                    if (!goal.Completed && goal.GoalDescription == "Gather Apples")
                    {
                        goal.CurrentAmount++;
                        goal.Evaluate();
                        Debug.Log($"Updated goal for quest: {quest.QuestName}");
                        questManagerScript.UpdateQuest(quest);
                        Destroy(transform.gameObject);
                    }
                }

                quest.CheckGoals();
            }
        }
    }
}
