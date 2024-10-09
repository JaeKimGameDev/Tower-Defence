using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpGame : MonoBehaviour
{
    public GameObject playNormalSpeedButton;
    // Start is called before the first frame update
    void Start()
    {
        playNormalSpeedButton.GetComponent<Toggle>().Select();
    }
    public void PlayNormalSpeed()
    {
        Time.timeScale = 1f;
    }
    public void PlayFasterSpeed()
    {
        Time.timeScale = 1.5f;
    }
    public void PlayFastestSpeed()
    {
        Time.timeScale = 2f;
    }
}
