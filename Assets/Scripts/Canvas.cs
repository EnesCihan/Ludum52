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
            finalSeedText.gameObject.SetActive(true);
            finalSeedText.text = SeedText.text;
            SeedText.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
        }
    }
}
