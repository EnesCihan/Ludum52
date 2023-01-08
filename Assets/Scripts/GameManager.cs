using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int SeedCount = 0;
    [SerializeField] TextMeshProUGUI SeedText;

    private void Update()
    {
        SeedText.text = ("Seed Number " + SeedCount);
    }
}
