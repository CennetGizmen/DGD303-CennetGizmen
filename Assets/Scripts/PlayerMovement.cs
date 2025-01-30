using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Variables")]
    [SerializeField] float moveSpeed;

    public float playerHealth;
    public float playerMaxHealth;


    int hInput;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        MovementManager();
    }

    void InputManager()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                hInput = 0;
            }
            else
            {
                hInput = 1;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            hInput = -1;
        }
        else
        {
            hInput = 0;
        }
    }

    void MovementManager()
    {
        transform.position += new Vector3(hInput, 0, 0) * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.3f, 10.3f), transform.position.y, 0);

    }

    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        if (playerHealth <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        GameManager.Instance.GameEnd();
    }
}
