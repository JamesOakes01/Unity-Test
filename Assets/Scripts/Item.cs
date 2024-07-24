using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class Item : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    [NonSerialized] public int itemValue;
    public bool showInWorldSpace = true;
    private bool spawnedUI;
    private GameObject thisworldNameUI;

    //public GameObject ItemNameUIPrefab;

    private void Start()
    {
        ReadItemsFile(itemID.ToString());
    }

    public void ReadItemsFile(string itemID)
    {
        StreamReader strReader = new StreamReader("C:\\Users\\James\\Documents\\GitHub\\Unity-Test\\TestProject\\Assets\\items.csv");
        string dataString;
        bool foundItem = false;

        // Skip header if exists
        strReader.ReadLine();

        while ((dataString = strReader.ReadLine()) != null)
        {
            var dataValues = dataString.Split(',');

            if (dataValues[0] == itemID)
            {
                itemName = dataValues[1];
                itemDescription = dataValues[2];
                itemValue = int.Parse(dataValues[3]); // Uncomment if itemValue is an integer

                foundItem = true;
                break;
            }
        }

        if (!foundItem)
        {
            // Handle case where itemID was not found
            Debug.LogError("ItemID: " + itemID + " was not found. Called from GameObject: " + this.gameObject.name);
            itemName = "Item not found";
            itemDescription = "Item not found";
            itemValue = 0;
        }
    }

    #region Getters and Setters
    public int GetItemID() { return itemID; }
    public string GetItemName() { return itemName; }
    public string GetItemDescription() { return itemDescription; }
    public int GetItemValue() { return itemValue; }

    public void SetItemID(int id) { itemID = id; }
    #endregion //Getters and Setters

    public void ShowItemNameInWorld()
    {
        if (thisworldNameUI == null)
        {
            spawnedUI = false;
        }

        if (showInWorldSpace && !spawnedUI)
        {
            Vector3 pos;
            pos = transform.position;
            pos.y += 0.5f;
            thisworldNameUI = Instantiate((GameObject)Resources.Load("Prefabs/ItemNameCanvas"), pos, Quaternion.identity);
            thisworldNameUI.transform.GetChild(0).GetComponent<TMP_Text>().text = itemName;
            spawnedUI = true;
        }
    }
}

