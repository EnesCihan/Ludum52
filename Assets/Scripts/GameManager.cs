using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int SeedCount;
    [SerializeField] TextMeshProUGUI SeedText;
    [SerializeField] Canvas canvas;
    private void Awake()
    {
        SeedCount = 0;
    }
    private void Update()
    {
        SeedText.text = (SeedCount.ToString());
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoBackMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
