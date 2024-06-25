using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;
using System.ComponentModel;
using Unity.Collections;
using UnityEditor;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    public int itemID;
    [Unity.Collections.ReadOnly] public static string itemName;
    public string itemDescription;
    [NonSerialized] public int itemValue;

    private void Start()
    {
        ReadItemsFile(itemID.ToString());
    }

    void ReadItemsFile(string itemID)
    {
        StreamReader strReader = new StreamReader("C:\\Users\\James\\Documents\\UnityProjects\\TestProject\\Assets\\items.csv");
        string data_String;
        bool foundItem = false;

        // Skip header if exists
        strReader.ReadLine();

        while ((data_String = strReader.ReadLine()) != null)
        {
            var data_values = data_String.Split(',');

            if (data_values[0] == itemID)
            {
                itemName = data_values[1];
                itemDescription = data_values[2];
                itemValue = int.Parse(data_values[3]); // Uncomment if itemValue is an integer

                foundItem = true;
                break;
            }
        }

        if (!foundItem)
        {
            // Handle case where itemID was not found
            Debug.LogError("ItemID: " + itemID + " was not found. Called from GameObect: " + this.gameObject.name);
            itemName = "Item not found";
            itemDescription = "Item not found";
            itemValue = 0;
        }
    }

    #region Getters and Setters
    public int GetItemID() { return itemID; }
    public static string GetItemName() { return itemName; }
    public string GetItemDescription() { return itemDescription; }
    public int GetItemValue() { return itemValue; }

    public void SetItemID(int id) { itemID = id; }
    #endregion //Getters and Setters
}
