using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject questLog; 

    public void ToggleInventory()
    {
        inventory.SetActive(inventory.activeSelf ? false : true);        
    }

    public void ToggleQuestLog()
    {
        questLog.SetActive(!questLog.activeSelf);        
    }
}
