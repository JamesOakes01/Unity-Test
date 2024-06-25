using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lookingAtDistance;
    [SerializeField] TextMeshProUGUI text;
    private GameObject lookingAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, lookingAtDistance))
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
            //Debug.Log(itemDes);
            text.text = itemDes;
        }
    }
}
