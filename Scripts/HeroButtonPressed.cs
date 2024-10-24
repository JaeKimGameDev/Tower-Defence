using UnityEngine;

public class HeroButtonPressed : MonoBehaviour
{
    public BuildManager BuildManager;

    private void OnEnable()
    {
        Debug.Log("testing");
    }
    private bool EnableHeroButton()
    {
        //BuildManager.EnableHero();
        return true;
    }
    
}
