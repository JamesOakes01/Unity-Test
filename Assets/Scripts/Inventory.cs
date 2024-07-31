using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using static UnityEditor.Progress;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<int> itemsInInventory;
    public List<int> quantityOfInventory;
    public List<GameObject> inventoryEntries;

    public GameObject InventoryUI;
    public GameObject InventoryEntryPrefab;
    public ItemLookup ItemLookup;
    public bool isInventoryOpen = false;
    //Dictionary<int, int> inventoryDict = new Dictionary<int, int>();
    // Start is called before the first frame update
    void Start()
    {
        //LoadInventory();
        //PrintInventory();
        //Invoke("DisplayInventory",0.1f); //using invoke because in start the values for preferred height are always zero before the first frame update
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isInventoryOpen)
            {
                isInventoryOpen = true;
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        isInventoryOpen = true;
        Cursor.lockState = CursorLockMode.None;
        ReadInventoryFile();
        
        Invoke("DisplayInventory", 0.1f);
        Invoke("PauseTime", 0.1f);
        
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void CloseInventory()
    {
        isInventoryOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        InventoryUI.SetActive(false);

        //destroy the old inventory entries
        for (int i = 0; i < inventoryEntries.Count; i++)
        {
            Destroy(inventoryEntries[i]);
        }

        Time.timeScale = 1f;
    }

    public void DisplayInventory()
    {
        InventoryUI.SetActive(true);
        GameObject content = InventoryUI.transform.Find("Scroll View/Viewport/Content").gameObject;

        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            GameObject entry = Instantiate(InventoryEntryPrefab, content.transform);
            entry.name = "item" + itemsInInventory[i].ToString();
            inventoryEntries.Add(entry);

            //Getting references
            TMP_Text titleText = entry.transform.Find("TitleText").GetComponent<TMP_Text>();
            TMP_Text descText = entry.transform.Find("DescriptionText").GetComponent<TMP_Text>();
            TMP_Text valueText = entry.transform.Find("ValueText").GetComponent<TMP_Text>();
            TMP_Text quantityText = entry.transform.Find("QuantityText").GetComponent<TMP_Text>();
            UnityEngine.UI.Image image = entry.transform.Find("Image").GetComponent<UnityEngine.UI.Image>();

            //Settings values
            titleText.text = ItemLookup.LookUpItemName(itemsInInventory[i]);
            descText.text = ItemLookup.LookUpDesc(itemsInInventory[i]);
            valueText.text = ItemLookup.LookUpValue(itemsInInventory[i]).ToString();
            quantityText.text = quantityOfInventory[i].ToString();
            Sprite icon = Resources.Load<Sprite>("ItemImages/" + itemsInInventory[i].ToString());
            image.sprite = icon;
        }

        Invoke("SetInventoryLayout", 0.01f);
    }

    public void SetInventoryLayout()
    {
        GameObject content = InventoryUI.transform.Find("Scroll View/Viewport/Content").gameObject;
        RectTransform trans = content.GetComponent<RectTransform>();
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, content.GetComponent<VerticalLayoutGroup>().minHeight);
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
        itemsInInventory.Clear();
        quantityOfInventory.Clear();
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
