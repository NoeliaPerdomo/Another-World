using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDamage : MonoBehaviour
{ 
    [SerializeField]
    [Range(2, 10)]
    private int damagePoints = 2;
    public int DamagePoints { get { return damagePoints; } }
}
