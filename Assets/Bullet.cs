using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.left * bulletSpeed * Time.deltaTime);
    }
}