using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*//Vector3 startLoc;
    public Vector3 endLoc;
    // Start is called before the first frame update
    void Start()
    {
        //startLoc = transform.position;
        //transform.position = Vector3.Lerp(transform.position, endLoc, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lerping");
        transform.position = Vector3.Lerp(transform.position, endLoc, 1);
    }*/

    public Transform from;
    public Transform to;
    float speed = 0.01f;
    float timeCount = 0.0f;

    float startTime;
    float journeyLength;

    private void Start()
    {
        from = this.gameObject.transform;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(from.position, to.position);
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;


        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;
        if (fractionOfJourney > 0.01)
        {
            Debug.Log("Door opened");
            Destroy(this);
        }
        //Debug.Log(fractionOfJourney);

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(from.position, to.position, fractionOfJourney);
    }
}
