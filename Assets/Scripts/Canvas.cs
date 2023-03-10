using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] TextMeshProUGUI SeedText;
    [SerializeField] TextMeshProUGUI finalSeedText;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (playerController.isDead)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            finalSeedText.text = SeedText.text;
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
        }
    }
}
