using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class item_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Getting Gun...");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        BasicMovement bm = player.GetComponent<BasicMovement>();
        GameObject gun = bm.GetLookingAt();
        Destroy(gun);
        Vector3 pos = player.transform.position;
        pos.z += 1f;
        GameObject gunInstance = Instantiate((GameObject)Resources.Load("Prefabs/Glock18"), pos, Quaternion.identity);
        gunInstance.transform.parent = player.transform;
        gunInstance.transform.localPosition = Vector3.right;
        gunInstance.transform.localRotation = Quaternion.Euler(0,90,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
