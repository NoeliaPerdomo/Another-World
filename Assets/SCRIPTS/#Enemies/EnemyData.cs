using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour

{
    [SerializeField]
    [Range(1, 10)]
    private int live = 10;
    public int HP { get { return live; } }

    public void Damage(int value)
    {
        live -= value;
        if (live <= 0)
        {
            Destroy(gameObject);
        }
    }
}

