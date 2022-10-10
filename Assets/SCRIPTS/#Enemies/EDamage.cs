using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EDamage : MonoBehaviour
{
    public int live = 10;
    public int Damage = 2;

    //public Slider sliderEnemy;

    //private void Update()
    //{
     //   sliderEnemy.value = live;
   // }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("punch"))
        {
            live -= Damage;
            Debug.Log("recibiendo danio");
            deadEnemy();
        }
    }

    void deadEnemy()
    {
        if (live <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
