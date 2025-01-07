using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Npc_Information : MonoBehaviour
{
    
    [Header("Npc Information")]
    [SerializeField] public string Npc_name;
    [SerializeField] public bool isQuestAvailable;

    private void Awake() {
       
        
    }
    void Start()
    {
        isQuestAvailable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public void UpdateQuestAvailability(){
        isQuestAvailable = false;
    }
}
