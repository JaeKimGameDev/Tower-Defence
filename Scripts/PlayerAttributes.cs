using TMPro;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public TextMeshProUGUI playerResourceText;
    public TextMeshProUGUI playerLifeText;
    public int playerResource = 2;
    public int playerLife = 25;
    public GameObject gameMenu;
    public int enemiesKilled = 0;
    public TextMeshProUGUI playerEliminationsText;
    public int rewardPlayerAfterElim = 15;

    void Start()
    {
        playerResourceText.text = playerResource.ToString();
        playerLifeText.text = playerLife.ToString();
        enemiesKilled = 0;
        playerEliminationsText.text = "Elimninations: " + enemiesKilled.ToString();
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
        playerLife -= 1;
        playerLifeText.text = playerLife.ToString();
        if (playerLife <= 0)
        {
            gameMenu.GetComponent<GameMenuScript>().GameOver();
        }
    }
    public int GetResource()
    {
        return playerResource;
    }
    public void IncrementEliminations()
    {
        enemiesKilled++;
        playerEliminationsText.text = "Elimninations: " + enemiesKilled.ToString();
        if (enemiesKilled % rewardPlayerAfterElim == 0)
        {
            IncrementPlayerResource(1);
        }
    }
}