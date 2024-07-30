using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemLookup : MonoBehaviour
{
    private int itemID;
    private string itemName;
    private string itemDescription;
    private int itemValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadItemsFile(string itemID)
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

    public string LookUpItemName(int itemIDToSearch)
    {
        ReadItemsFile(itemIDToSearch.ToString());
        return itemName;
    }

    public string LookUpDesc(int itemIDToSearch)
    {
        ReadItemsFile(itemIDToSearch.ToString());
        return itemDescription;
    }
}
