using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Gem : MonoBehaviour
{

    public UnityEvent OnTriggerButton3D;

    public GameObject objPoints;
    public float points;


    public AudioClip SoundCatchGem;


    public GameObject GemWin;
    public AudioClip WinSound;

    public AudioSource CatchGem;
    public AudioSource winSound;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerButton3D?.Invoke();
            objPoints.GetComponent<QuantityGems>().quantityGems += points;
            CatchGem.clip = SoundCatchGem;
            CatchGem.Play();
            if (objPoints.GetComponent<QuantityGems>().quantityGems >=6)
            {
                Win();
            }

            //this.gameObject.SetActive(false);
        }
    }

    void Win()
    {
        winSound.clip = WinSound;
        winSound.Play();
        GemWin.SetActive(true);
    }
}


