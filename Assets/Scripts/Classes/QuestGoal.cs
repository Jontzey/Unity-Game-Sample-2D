using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class QuestGoal : MonoBehaviour
{
    public string Description;
    public string GoalDescription;
    public bool Completed;
    public int CurrentAmount;
    public int RequiredAmount;

    // private void Update() {
    //     Debug.Log(CurrentAmount);
    // }
    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        Debug.Log("Quest Goal Completed!");
    }
}
