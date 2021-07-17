using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public PlayerItemData playerData;
    public int value;
    public string objectType;

    private string[] objectTypeArray = new string[] {"batteryAmount", "cardAmount", "fuse", "finalFuse"};
    public void Collectible()
    {
        gameObject.SetActive(false);
        PointGiver(objectType);
    }

    public void Crate()
    {

    }

    public void DetectionChecker(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_fresnelPower", 2);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_fresnelPower", 100);
        }
    }

    private void PointGiver(string oType)
    {
        if(oType == "Battery")
        {
            ++playerData.batteryAmount;
        }
        else if(oType == "Card")
        {
            ++playerData.cardAmount;
        }
        else if (oType == "Fuse")
        {
            ++playerData.fuse;
        }
        else if (oType == "FinalFuse")
        {
            ++playerData.finalFuse;
        }
    }
}
