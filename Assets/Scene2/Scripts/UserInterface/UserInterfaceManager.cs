using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
  [SerializeField]  GameObject WorldCanvas;
  [SerializeField]  GameObject UI_Interactable;

  [SerializeField]  GameObject QuestMenu;

  [SerializeField] public NpcInformation npcInformation;

  [SerializeField] private AudioClip OpeningQuestAudio;
  [SerializeField] private AudioSource audioSource;
    private void Awake() {
        WorldCanvas = GameObject.Find("WorldCanvas");
        QuestMenu = GameObject.Find("QuestMenu");
        npcInformation = FindAnyObjectByType<NpcInformation>();
        audioSource = GetComponent<AudioSource>();

        UI_Interactable = GameObject.Find("WorldCanvas/Interactable");
    }
    void Start()
    {   
         UI_Interactable.SetActive(false);
         QuestMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void IsInteractAble(bool CanInteract, NpcInformation npcInfo){
        if(CanInteract){
            npcInformation = npcInfo;
            UI_Interactable.SetActive(true);
        }else{
            UI_Interactable.SetActive(false);
        }
    }

    public void OpenQuestMenu(Quest quest){
        QuestMenu.SetActive(!QuestMenu.activeSelf);
        if(OpeningQuestAudio != null){
            audioSource.PlayOneShot(OpeningQuestAudio);
        }
        TextMeshProUGUI QuestName = GameObject.Find("QuestMenu/QuestName").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI QuestGoal= GameObject.Find("QuestMenu/QuestGoal").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI QuestDescription = GameObject.Find("QuestMenu/QuestDescription").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI AcceptBtnText = GameObject.Find("QuestMenu/AcceptBtn/BtnText").GetComponent<TextMeshProUGUI>();
        Button AcceptBtn = GameObject.Find("QuestMenu/AcceptBtn").GetComponent<Button>();
        // Button CloseBtn = GameObject.Find("QuestMenu/CloseBtn").GetComponent<Button>();
        QuestName.text = quest.QuestName.ToString();
        QuestGoal.text = quest.QuestGoalDescription.ToString();
        QuestDescription.text = quest.Description.ToString();
        
        if(quest.QuestComplete){
            AcceptBtnText.text = "Complete";
            AcceptBtn.onClick.RemoveAllListeners();
            AcceptBtn.onClick.AddListener(npcInformation.CompleteRewardQuest);
        }else{
            if(!quest.IsQuestActive){
                AcceptBtnText.text = "Accept";
                AcceptBtn.onClick.RemoveAllListeners();
                AcceptBtn.onClick.AddListener(npcInformation.GiveQuest);
            }else{
                AcceptBtn.onClick.RemoveAllListeners();
                AcceptBtnText.text = "InProgress";
                Debug.Log("Quest is Active");
            }

        }
        
    }

    public void CloseQuestMenu(){
         QuestMenu.SetActive(false);
    }


    public void AddTextMessage(string ItemCollectedSentence){
        npcInformation.UpdateCanvasUI();
        StartCoroutine(CreateTextMessage(ItemCollectedSentence));
    }

    public IEnumerator CreateTextMessage(string ItemCollectedSentence){
       
        GameObject MsgGrid = GameObject.Find("MessagesGrid");

        
        GameObject newMessageObject = new GameObject("NewMessage");

        
        TextMeshProUGUI newText = newMessageObject.AddComponent<TextMeshProUGUI>();

        newText.text = ItemCollectedSentence.ToString();


        newText.fontSize = 24;
        newText.color = Color.white;

       
        newMessageObject.transform.SetParent(MsgGrid.transform, false);

          // Fade-out effekt variabler
        float fadeDuration = 2.0f;
        float startAlpha = 1f;
        float endAlpha = 0f;
        float elapsedTime = 0f;

        // Starta fade-out
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            newText.color = new Color(newText.color.r, newText.color.g, newText.color.b, alpha);
            yield return null;
        }

        
        Destroy(newMessageObject);
    }
}
