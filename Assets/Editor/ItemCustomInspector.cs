using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class TestOnInspector : Editor
{
    public Item item;
    public override void OnInspectorGUI()
    {
        GUILayout.Label("This is a Label in a Custom Editor");
        GUILayout.RepeatButton("text");
        string itemID = GUILayout.TextField("test");
        item.SetItemID(int.Parse(itemID));
        //var name1 = Item.GetItemName().ToString();
        GUILayout.Label("Item name: " + Item.GetItemName());
        //string names3 = GUILayout.TextField("test");
        GUIContent content = new GUIContent(Item.GetItemName());
        GUILayout.Box(content: content);
    }
}
