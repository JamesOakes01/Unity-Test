using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class TestOnInspector : Editor
{
    public override void OnInspectorGUI()
    {
        // Get the target object
        Item item = (Item)target;

        // Display label
        GUILayout.Label("Item System: ");

        // TextField for itemID
        item.itemID = EditorGUILayout.IntField("Item ID", item.itemID);


        item.showInWorldSpace = EditorGUILayout.Toggle("Show Item in world space ", item.showInWorldSpace);

        // Display item details
        EditorGUILayout.LabelField("Item Name:", item.itemName);
        EditorGUILayout.LabelField("Item Description:", item.itemDescription);
        EditorGUILayout.LabelField("Item Value:", item.itemValue.ToString());
        
        //item.ItemNameUIPrefab = (GameObject)EditorGUILayout.ObjectField("Item Name UI Prefab", item.ItemNameUIPrefab, typeof(GameObject), false);

        // Create a button to update the item
        if (GUILayout.Button("Load Item Data"))
        {
            item.ReadItemsFile(item.itemID.ToString());
            // Ensure changes are saved and displayed in the inspector
            EditorUtility.SetDirty(item);
        }
    }
}

