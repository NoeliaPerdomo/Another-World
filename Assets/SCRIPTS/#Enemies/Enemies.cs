using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemies : MonoBehaviour
{

    [SerializeField] [Range(1f, 20f)] public float speed = 3f;


    enum EnemyTypes { Stalker, Rioter }
    [SerializeField] EnemyTypes enemyType;

    [SerializeField] Transform playerTransform;

    [SerializeField] [Range(1f, 10f)] public float hp = 10f;
    public int punchDamage;

    private EnemyData enemyData;
    public static event Action<int> OnChangeHP;



    public float cameraAxisX = 0;


    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        HUDManager.SetHPBar(enemyData.HP);
    }

    void Update()
    {
        switch (enemyType)
        {
            case EnemyTypes.Stalker:
                ChasePlayer();
                break;

            case EnemyTypes.Rioter:
                RotateAroundPlayer();
                break;
        }
    }

    private void RotateAroundPlayer()
    {
        LookPlayer();
        transform.RotateAround(playerTransform.position, Vector3.zero, 5f * Time.deltaTime);

    }

    private void ChasePlayer()
    {
        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 2f)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }

        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.1f * Time.deltaTime);

    }

    private void LookPlayer()
    {
        transform.LookAt(playerTransform);
    }

   private void OnColissionEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            enemyData.Damage(other.gameObject.GetComponent<EnemiesDamage>().DamagePoints);
            HUDManager.SetHPBar(enemyData.HP);
            OnChangeHP?.Invoke(enemyData.HP);
        }
        
    }

}

