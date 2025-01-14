using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update



    //Weapon Collider;
    public Collider2D WeaponCollider2D;

    private void Awake() {
        WeaponCollider2D = transform.Find("Root/BodySet/P_Body/ArmSet/ArmR/P_RArm/P_Weapon").GetComponent<Collider2D>();
    }
    void Start()
    {
        WeaponCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DealDamage(){
        StartCoroutine(WaitForNextAttack());
    }

    private IEnumerator WaitForNextAttack(){
        WeaponCollider2D.enabled = true;
        yield return new WaitForSeconds(0.2f);
        WeaponCollider2D.enabled = false;
    }
}
