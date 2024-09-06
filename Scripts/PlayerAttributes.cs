using TMPro;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public TextMeshProUGUI playerResourceText;
    public TextMeshProUGUI playerLifeText;
    public int playerResource = 3;
    public int playerLife = 25;

    void Start()
    {
        playerResourceText.text = "Resources: " + playerResource.ToString();
        playerLifeText.text = "Life: " + playerLife.ToString();
    }

    public void incrementPlayerResource(int resourceAmount)
    {
        playerResource += resourceAmount;
        playerResourceText.text = "Resources:" + playerResource.ToString();
    }

    public void decrementPlayerResource(int resourceAmount)
    {
        playerResource -= resourceAmount;
        playerResourceText.text = "Resources:" + playerResource.ToString();
    }

    public void playerLifeLost()
    {
        playerLife--;
        playerLifeText.text = "Life: " + playerLife.ToString();
    }
    
}
