using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject questMenu;
    private bool isQuestMenuOpen;
    void Start()
    {
        questMenu = transform.Find("QuestMenu").GetComponent<GameObject>();
        isQuestMenuOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


   public void OpenQuestMenu(){
        if(isQuestMenuOpen){
            questMenu.SetActive(false);
            isQuestMenuOpen = false;
        }else{
            questMenu.SetActive(true);
            isQuestMenuOpen = true;
        }
    }


    public void DeclineQuest(){
        Debug.Log("Declined Quest");
        questMenu.SetActive(false);
        isQuestMenuOpen = false;
    }
}
