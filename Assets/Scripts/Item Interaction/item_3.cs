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
        Vector3 pos = this.transform.position;
        pos.z += 1f;
        GameObject gunInstance = Instantiate((GameObject)Resources.Load("Prefabs/Glock18"), pos, Quaternion.Euler(0,0,0));
        gunInstance.transform.parent = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
