using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;

    public AudioClip SoundPlayerDamageHit;
    public AudioClip SoundPowerUp;

    public AudioSource PlayerDamageHit;
    public AudioSource PowerUp;
    public AudioSource PushButton;
    public AudioSource CatchGem;



    public static event Action<int> OnChangeHP;


    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        HUDManager.SetHPBar(playerData.HP);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Munitions"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<Munition>().DamagePoints);
            PlayerDamageHit.clip = SoundPlayerDamageHit;
            PlayerDamageHit.Play();
            Destroy(other.gameObject);
            HUDManager.SetHPBar(playerData.HP);
            OnChangeHP?.Invoke(playerData.HP);
        }

        if (other.gameObject.CompareTag("LavaTrap"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<LavaDamage>().DamagePoints);
            PlayerDamageHit.clip = SoundPlayerDamageHit;
            PlayerDamageHit.Play();
            HUDManager.SetHPBar(playerData.HP);
            OnChangeHP?.Invoke(playerData.HP);
        }

        if (other.gameObject.CompareTag("Enemies"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<EnemiesDamage>().DamagePoints);
            PlayerDamageHit.clip = SoundPlayerDamageHit;
            PlayerDamageHit.Play();
            HUDManager.SetHPBar(playerData.HP);
            OnChangeHP?.Invoke(playerData.HP);
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            playerData.Healing(other.gameObject.GetComponent<Heart>().HealPoints);
            Destroy(other.gameObject);
            PowerUp.clip = SoundPowerUp;
            PowerUp.Play();
            HUDManager.SetHPBar(playerData.HP);
            PlayerCollision.OnChangeHP?.Invoke(playerData.HP);

            GameManager.score++;
            Debug.Log(GameManager.score);
        }

        if (other.gameObject.CompareTag("button"))
        {
            PushButton.Play();
        }

        if (other.gameObject.CompareTag("gem"))
        {
            CatchGem.Play();
        }
    }
}



