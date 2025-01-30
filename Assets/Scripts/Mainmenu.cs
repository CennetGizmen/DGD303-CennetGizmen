using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    bool isCreditsOpen = false;

    [SerializeField] GameObject creditsScreen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCreditsOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            isCreditsOpen = false;
            creditsScreen.SetActive(false);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CreditsButton()
    {
        isCreditsOpen = true;
        creditsScreen.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
