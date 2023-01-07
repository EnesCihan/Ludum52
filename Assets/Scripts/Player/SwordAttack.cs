using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
            
    }
    void Attack()
    {
            GetComponent<Animator>().SetTrigger("isAttack");
    }
    
    void OpenAttackArea()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    void CloseAttackArea()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
