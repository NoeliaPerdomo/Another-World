using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]
    [Range(2, 20)]
    private int healPoints = 20;
    public int HealPoints { get { return healPoints; } }
}
