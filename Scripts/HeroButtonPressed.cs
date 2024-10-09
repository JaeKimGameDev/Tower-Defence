using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroButtonPressed : MonoBehaviour
{
    public BuildManager BuildManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
