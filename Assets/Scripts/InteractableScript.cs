using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public PlayerItemData playerData;
    public int value;
    public string objectType;

    private bool isActivated = true;

    public void Interacting()
    {
        if (gameObject.CompareTag("Collectible"))
        {
            Collectible();
        }
        else if (gameObject.CompareTag("Crate"))
        {
            Crate();
        }
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

    private void Collectible()
    {
        gameObject.SetActive(false);
        PointGiver(objectType);
    }

    private void Crate()
    {
        if(isActivated)
        {
            gameObject.GetComponent<Animator>().SetBool("activated", isActivated);
            isActivated = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("activated", isActivated);
            isActivated = true;
        }
    }

    private void PointGiver(string oType)
    {
        if(oType == "Battery")
        {
            ++playerData.currentBatteryAmount;
        }
        else if(oType == "Card")
        {
            ++playerData.currentCardAmount;
        }
        else if (oType == "Fuse")
        {
            ++playerData.currentFuseAmount;
        }
        else if (oType == "FinalFuse")
        {
            ++playerData.currentFinalFuseAmount;
        }
    }
}
