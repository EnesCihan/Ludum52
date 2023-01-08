using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Refrence")]
    [SerializeField] AudioSource audioSource;
    [Header("Sounds")]
    [SerializeField] AudioClip clip0;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;


    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("Source0"):
                audioSource.PlayOneShot(clip0);
                break;
            case ("Source1"):
                audioSource.PlayOneShot(clip1);
                break;
            case ("Source2"):
                audioSource.PlayOneShot(clip2);
                break;
            case ("Source3"):
                audioSource.PlayOneShot(clip3);
                break;
        }
    }




}
