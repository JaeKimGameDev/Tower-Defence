using UnityEngine;

public class SpeedUpGame : MonoBehaviour
{
    public GameObject playNormalPressed;
    public GameObject playFasterPressed;
    public GameObject playFastestPressed;
    public float gameSpeed=1f;

    void Start()
    {
        PlayNormalSpeed();
    }
    public void PlayNormalSpeed()
    {
        playNormalPressed.SetActive(true);
        playFasterPressed.SetActive(false);
        playFastestPressed.SetActive(false);
        gameSpeed = 1f;
        Time.timeScale = 1f;
    }
    public void PlayFasterSpeed()
    {
        playNormalPressed.SetActive(false);
        playFasterPressed.SetActive(true);
        playFastestPressed.SetActive(false);
        gameSpeed = 1.5f;
        Time.timeScale = 1.5f;
    }
    public void PlayFastestSpeed()
    {
        playNormalPressed.SetActive(false);
        playFasterPressed.SetActive(false);
        playFastestPressed.SetActive(true);
        gameSpeed = 2f;
        Time.timeScale = 2f;
    }
}
