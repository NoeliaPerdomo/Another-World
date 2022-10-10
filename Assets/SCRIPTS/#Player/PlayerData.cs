using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
    [SerializeField] [Range(1, 200)] private int live = 200;
    public int HP { get { return live; } }

    public GameObject edead;
    public AudioClip SoundGameOver;

    public AudioSource GameOver;




    public void Healing(int value)
    {
        live += value;
    }

    public void Damage(int value)
    {
        live -= value;
        if (live <= 0)
        {
            dead();
        }


    }

    void dead()
    {
        GameOver.clip = SoundGameOver;
        GameOver.Play();
        edead.SetActive(true);
    }
}

