using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrap : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform endPoint;

    [SerializeField]
    [Range(1f, 20f)]
    private float rayDistance = 10;

    [SerializeField] private GameObject bullet;

    bool canShoot = true;

    void Start()
    {
    }


    void Update()
    {
        LavaTrapRaycast();
    }

    private void LavaTrapRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player") && canShoot)
            {
                Debug.Log("COLLISION CON PLAYER");
                Instantiate(bullet, shootPoint.transform.position, bullet.transform.rotation);
                canShoot = false;
                Invoke("delayShoot", 1f);
            }
        }
    }

    void delayShoot()
    {
        canShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 direction = shootPoint.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawLine(shootPoint.position, endPoint.position);
    }

}

