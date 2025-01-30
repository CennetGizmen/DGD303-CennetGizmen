using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    float timer = 0;

    [SerializeField] GameObject videoPlayer;
    [SerializeField] GameObject _image;

    bool isImageActive = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 20)
        {
            videoPlayer.SetActive(false);
            _image.SetActive(true);
            isImageActive = true;
        }
        if(isImageActive&&Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
