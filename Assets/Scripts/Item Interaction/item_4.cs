using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Opening door");
        //Destroy(GetComponent<BasicMovement>().GetLookingAt());
        GetComponent<BasicMovement>().GetLookingAt().GetComponent<Door>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
