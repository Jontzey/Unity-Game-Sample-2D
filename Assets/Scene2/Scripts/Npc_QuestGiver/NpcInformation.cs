using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInformation : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] public Quest quest;
    // [SerializeField] public string Name;
    // [SerializeField] public string Name;
    // [SerializeField] public string Name;
    [SerializeField] public bool IsPlayerInRange;

    [SerializeField] public bool IsNpcInteractable;


    UserInterfaceManager userInterfaceManager;
    NpcCanvasUI npcCanvasUI;
    private void Awake() {
        userInterfaceManager = FindAnyObjectByType<UserInterfaceManager>();
        npcCanvasUI = GetComponent<NpcCanvasUI>();
    }
    void Start()
    {
        IsNpcInteractable = true;
        IsPlayerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && IsPlayerInRange && IsNpcInteractable){
               
                userInterfaceManager.OpenQuestMenu(quest);
        }
    }



    public void GiveQuest(){
        quest.IsQuestActive = true;
        QuestManager.instance.AddQuest(quest);
        userInterfaceManager.CloseQuestMenu();
        UpdateCanvasUI();
    }


    public void CompleteRewardQuest(){
        Debug.Log("Player was rewarded with: "+ quest.ExperienceReward + " experience");
        IsNpcInteractable = false;
        userInterfaceManager.CloseQuestMenu();
        userInterfaceManager.IsInteractAble(false,this);
        quest.IsQuestActive = false;
        UpdateCanvasUI();
        userInterfaceManager.AddTextMessage($"Completed : {quest.QuestName.ToString()}");
        QuestManager.instance.RemoveQuest(quest);
    }


    public void UpdateCanvasUI(){
        npcCanvasUI.UpdateQuestStatusUI();
    }
}
