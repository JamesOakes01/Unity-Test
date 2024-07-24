using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Shooting...");
            //Quaternion rot = this.transform.rotation;
            //rot.y += 90;

            Instantiate((GameObject)Resources.Load("Prefabs/Bullet"), this.transform.position, this.transform.rotation);
        }
    }
}
