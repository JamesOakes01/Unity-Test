using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float minBulletSpeed;
    private Rigidbody rb;
    //private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.left * (bulletSpeed * 1000) * Time.deltaTime);
        //Debug.Log("Min bullet speed is: " + minBulletSpeed);
        //Debug.Log(rb.velocity.magnitude);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        /*if (counter > 0)
        {
            Debug.Log("current velocity: " + rb.velocity.magnitude + ". minbulletspeed: " + minBulletSpeed);
            if (rb.velocity.magnitude < minBulletSpeed)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            counter++;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}