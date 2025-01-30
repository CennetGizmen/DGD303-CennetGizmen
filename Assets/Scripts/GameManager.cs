using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is null");

            return _instance;

        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] PlayerShooting playerShooting;

    [SerializeField] ScreenShake screenShake;

    [SerializeField] UI uI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameEnd()
    {
        //End Game
        SceneManager.LoadScene("LostScene");
    }
    public void GameWin()
    {

        SceneManager.LoadScene("WinScene");

    }
    public void ChangeBullet(int bulletNumber)
    {
        playerShooting.ChangeBullet(bulletNumber);
        uI.ChangeBullet(bulletNumber);

        //BulletPrefab should change
        //UI should be updated
    }

    public void ScreenShake(float amplitude, float duration)

    {
        screenShake.ShakeCamera(amplitude, duration);
    }
}
