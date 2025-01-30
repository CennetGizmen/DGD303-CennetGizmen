using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnemy : MonoBehaviour
{

    [SerializeField] GameObject enemyBulletPrefab;

    [SerializeField] float shootCooldown;

    [SerializeField] float bulletAmount;

    float shootTimer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCooldown && bulletAmount > 0)

        {
            Shoot();
            shootTimer = 0;
            bulletAmount--;
        }
    }
    void Shoot()
    {
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }
}
