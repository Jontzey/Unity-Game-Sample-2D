using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUi_stats : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField] TextMeshProUGUI Ch_Name;
    [SerializeField] TextMeshProUGUI Ch_lvl;
    [SerializeField]
    PlayerStats playerStats;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.transform.Find("UnitRoot").gameObject.GetComponent<PlayerStats>();
        Ch_Name = transform.Find("Ch_Name").gameObject.GetComponent<TextMeshProUGUI>();
        Ch_lvl = transform.Find("Ch_lvl").gameObject.GetComponent<TextMeshProUGUI>();

        Ch_Name.text = playerStats.playerName;
        Ch_lvl.text = playerStats.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
