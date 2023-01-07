using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
