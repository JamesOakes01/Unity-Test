using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] bool usePhysicsMovement;
    [SerializeField] float speed;
    [SerializeField] float physicsSpeed;
    [SerializeField] float lookingAtDistance;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float lookSpeed;
    [SerializeField] Rigidbody rb;
    private GameObject lookingAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Movement()
    {
        if (usePhysicsMovement)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(Vector3.forward * physicsSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddRelativeForce(Vector3.left * physicsSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(Vector3.back * physicsSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeForce(Vector3.right * physicsSpeed * Time.deltaTime);
            }

            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        Movement();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, lookingAtDistance))
        {
            //Debug.Log("There is something in front of the object!");
            //Debug.Log(hit.transform.gameObject.name);
            lookingAt = hit.transform.gameObject;
            if (lookingAt.GetComponent<Item>() != null)
            {
                //Debug.Log("looking at an item");
                SetLookingAtUI(lookingAt);
            }
        }
        else
        {
            SetLookingAtUI(null);
        }
    }

    private void SetLookingAtUI(GameObject lookingAt)
    {
        if (lookingAt == null)
        {
            text.text = "";
        }
        else
        {
            string itemDes = lookingAt.GetComponent<Item>().itemDescription;
            lookingAt.GetComponent<Item>().ShowItemNameInWorld();
            //Debug.Log(itemDes);
            text.text = itemDes;
        }
    }
}
