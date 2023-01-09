using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    [SerializeField] GameObject seed1;
    [SerializeField] GameObject seed2;
    void Start()
    {
        StartCoroutine(Plants());
        StartCoroutine(ScenePast());
    }


    IEnumerator Plants()
    {
        yield return new WaitForSeconds(25f);

        seed1.SetActive(true);
        seed2.SetActive(true);
    }

    IEnumerator ScenePast()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
