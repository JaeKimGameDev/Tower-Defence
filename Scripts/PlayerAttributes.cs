using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    public TextMeshProUGUI playerResourceText;
    public TextMeshProUGUI playerLifeText;
    public int playerResource = 6;
    public int playerLife = 25;

    void Start()
    {
        playerResourceText.text = playerResource.ToString();
        playerLifeText.text = playerLife.ToString();
    }

    public void IncrementPlayerResource(int resourceAmount)
    {
        playerResource += resourceAmount;
        playerResourceText.text = playerResource.ToString();
    }

    public void DecrementPlayerResource(int resourceAmount)
    {
        playerResource -= resourceAmount;
        playerResourceText.text = playerResource.ToString();
    }

    public void PlayerLifeLost()
    {
        playerLife--;
        playerLifeText.text = playerLife.ToString();
    }
}