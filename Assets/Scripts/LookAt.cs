using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private GameObject target;
    private Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //target = GameObject.FindGameObjectWithTag("Player");
        //targetTransform = target.transform;
        //targetTransform.rotation = Quaternion.Euler(0,0,0);
        transform.LookAt(target.transform);
    }
}
