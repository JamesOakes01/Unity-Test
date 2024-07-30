using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<int> itemsInInventory;
    public List<int> quantityOfInventory;

    public GameObject InventoryUI;
    //Dictionary<int, int> inventoryDict = new Dictionary<int, int>();
    // Start is called before the first frame update
    void Start()
    {
        LoadInventory();
        //Debug.Log(inventoryDict);
        PrintInventory();
        DisplayInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadInventory()
    {
        ReadInventoryFile();
    }

    public void DisplayInventory()
    {
        GameObject content = InventoryUI.transform.Find("Content").gameObject;
    }

    public void VerifyArraysMatch()
    {
        if (itemsInInventory.Count != quantityOfInventory.Count)
        {
            Debug.LogError("The length of the itemID and itemQuantity arrays are not equal!");
        }
    }

    public void PrintInventory()
    {
        VerifyArraysMatch();

        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            Debug.Log(itemsInInventory[i]+ "\n");
        }
        Debug.Log("\n");
        for (int i = 0; i < quantityOfInventory.Count; i++)
        {
            Debug.Log(quantityOfInventory[i] + "\n");
        }
    }

    public void ReadInventoryFile()
    {
        StreamReader strReader = new StreamReader("C:\\Users\\James\\Documents\\GitHub\\Unity-Test\\TestProject\\Assets\\inventory.csv");
        string dataString;

        // Skip header if exists
        strReader.ReadLine();

        for (int i = 0; (dataString = strReader.ReadLine()) != null; i++)
        {
            var dataValues = dataString.Split(',');
            itemsInInventory.Add(int.Parse(dataValues[0]));
            quantityOfInventory.Add(int.Parse(dataValues[1]));
        }
        VerifyArraysMatch();
    }
}
