using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            playerMovement.TakeDamage(20);
        }
    }
}
