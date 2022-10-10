using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HUDManager : MonoBehaviour
{
    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }


    [SerializeField] private Slider hpBar;
    

    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            PlayerCollision.OnChangeHP += SetHPBar;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static void SetHPBar(int newValue)
        {
            instance.hpBar.value = newValue;
        }

       
    }


