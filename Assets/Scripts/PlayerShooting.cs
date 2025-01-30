using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] float shootCooldown;

    [Header("Essentials")]
    [SerializeField] GameObject[] bulletPrefabs;
    [SerializeField] Transform barrelPos;

    float shootTimer;
    bool canShoot = true;

    GameObject currentBullet;

    float shakeAmount = 1;

    void Start()
    {
        currentBullet = bulletPrefabs[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootCooldown)
            {
                canShoot = true;
                shootTimer = 0;
            }
        }


        if (Input.GetMouseButton(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;
        Instantiate(currentBullet, barrelPos.transform.position, Quaternion.identity);
        GameManager.Instance.ScreenShake(shakeAmount, 0.15f);
    }
    public void ChangeBullet(int bulletNumber)
    {
        currentBullet = bulletPrefabs[bulletNumber];
        shakeAmount += 0.8f;
    }
}
