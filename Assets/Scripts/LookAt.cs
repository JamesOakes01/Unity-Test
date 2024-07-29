using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private GameObject target;
    private Transform targetTransform;
    private BasicMovement bm;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        bm = target.GetComponent<BasicMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        if (!bm.isLookingAtObj())
        {
            Destroy(this.gameObject);
        }
    }
}
