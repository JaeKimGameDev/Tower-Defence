using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    private GameObject defender;
    private List<GameObject> defenders;

    void OnMouseDown()
    {
        if (defender != null)
        {
            Debug.Log("Can't build there! - TODO display on screen");
            // or play an audio saying "I can't build there"
            return;
        }
        List<GameObject> defenderToBuild = BuildManager.instance.GetDefenderToBuild();
        for (int i = 0; i < defenderToBuild.Count; i++) 
        {
            defender = (GameObject)Instantiate(defenderToBuild[i], transform.position + positionOffset, transform.rotation);
        }
        
    }
}
