using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent OnTriggerButton3D;
    public AudioClip SoundPushButton;

    public AudioSource PushButton;


  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerButton3D?.Invoke();
            PushButton.clip = SoundPushButton;
            PushButton.Play();
        }

        {
            Destroy(gameObject);
        }
    }
}
