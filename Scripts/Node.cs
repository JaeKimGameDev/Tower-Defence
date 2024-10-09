using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    private GameObject defenderToBuild;
    private GameObject defender;
    public BuildManager buildManager;
    public Material defaultMaterial;
    public Material greenMaterial;
    public Material redMaterial;

    void OnMouseDown()
    {
        if (defender != null)
        {
            Debug.Log("Can't build there! - TODO display on screen");
            // or play an audio saying "I can't build there"
            return;
        }
        buildManager = buildManager.GetComponent<BuildManager>();
        if (buildManager.BuildID() == true)
        {
            defenderToBuild = BuildManager.instance.GetHeroDefenderToBuild();
        }
        else
        {
            defenderToBuild = BuildManager.instance.GetNormalDefenderToBuild();
        }
        defender = (GameObject)Instantiate(defenderToBuild, transform.position + positionOffset, transform.rotation);
        buildManager.SpawnedDefenders.Add(defender);
    }
    void OnMouseEnter()
    {
        if (defender == null)
        {
            GetComponent<MeshRenderer>().material = greenMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = redMaterial;
        }
    }
    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
