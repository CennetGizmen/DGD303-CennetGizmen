using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] int maxHealthPoints;
    [SerializeField] int healthPoints;


    [SerializeField] Material flashMaterial;
    Material startMaterial;
    SpriteRenderer sr;

    public WaveSpawner waveSpawner;
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        startMaterial = sr.material;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(int damageTaken)
    {
        healthPoints -= damageTaken;
        StartCoroutine(FlashEffect());
        if (healthPoints <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        //GameManager.Instance.ScreenShake(4, 0.3f);
        waveSpawner.currentEnemies.Remove(gameObject);
        Destroy(gameObject);
    }

    IEnumerator FlashEffect()

    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(0.25f);
        sr.material = startMaterial;

    }
}
