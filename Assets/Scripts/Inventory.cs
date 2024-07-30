using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
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
        //DisplayInventory();
        Debug.Log("invokign start...");
        Invoke("DisplayInventory",0.1f); //using invoke because in start the values for preferred height are always zero before the first frame update
    }

    //int counter = 0;
    // Update is called once per frame
    void Update()
    {
        //if (counter == 1)
        //    DisplayInventory();
        //else counter++;
    }

    public void LoadInventory()
    {
        ReadInventoryFile();
    }

    public void DisplayInventory()
    {
        GameObject content = InventoryUI.transform.Find("Scroll View/Viewport/Content").gameObject;
        RectTransform trans = content.GetComponent<RectTransform>();
        VerticalLayoutGroup vert = content.GetComponent<VerticalLayoutGroup>();
        float prefheight = vert.minHeight;
        Debug.Log("Pref height: " + prefheight);
        Debug.Log(trans.rect.height);
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, prefheight);
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
