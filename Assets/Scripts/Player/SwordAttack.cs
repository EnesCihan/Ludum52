using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            GetComponent<Animator>().SetTrigger("isAttack");
        }
    }

    void OpenAttackArea()
    {
        transform.GetChild(5).gameObject.SetActive(true);
    }

    void CloseAttackArea()
    {
        transform.GetChild(5).gameObject.SetActive(false);
    }
}
