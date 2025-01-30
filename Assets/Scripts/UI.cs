using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Image healthBarImage;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] Image[] darkenImages;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = playerMovement.playerHealth / playerMovement.playerMaxHealth;
    }

    public void ChangeBullet(int bulletNumber)
    {
        darkenImages[bulletNumber].gameObject.SetActive(false);
        darkenImages[bulletNumber - 1].gameObject.SetActive(true);
    }
}
