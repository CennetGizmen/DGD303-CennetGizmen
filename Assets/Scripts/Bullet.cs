using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int bulletDamage;

    [SerializeField] int direction;

    float destroyTimer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * moveSpeed * direction * Time.deltaTime;

        destroyTimer += Time.deltaTime;
        if (destroyTimer > 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
