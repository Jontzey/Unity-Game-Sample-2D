using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCanvasScale : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {

    }

    void Update()
    {
       transform.position = Player.transform.position + new Vector3(0.01f,0.01f,-1);
       transform.localScale = new Vector3(1,0,0);
    }
}
