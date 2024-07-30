using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoverPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), "Gizmos\\wall.png", true);
            Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, 0f, transform.localScale.z));
        }
    #endif
}
