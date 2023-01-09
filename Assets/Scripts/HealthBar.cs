using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerController playerController;
    public GameObject player;
    public Slider slider;

    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        
    }

    void Update()
    {
        SetHealth();
    }

   public void SetHealth()
    {
        slider.value = playerController.currentHealth;
    }
}
