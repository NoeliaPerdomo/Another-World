using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelUI : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Main");
    }
}

