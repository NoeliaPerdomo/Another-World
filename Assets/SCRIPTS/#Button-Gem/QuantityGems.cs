using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityGems : MonoBehaviour
{
    public float quantityGems;
    public Text textPoints;

private void Update()
    {
        textPoints.text = "DIAMANTES OBTENIDOS: " + quantityGems.ToString();
    }

}