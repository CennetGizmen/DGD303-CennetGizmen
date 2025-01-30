using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] float backgroundSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * backgroundSpeed * Time.deltaTime;
    }


}
