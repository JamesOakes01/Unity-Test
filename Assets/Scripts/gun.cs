using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class gun : MonoBehaviour
{
    private float timer = 0;
    private int roundCount = 8;
    private AudioSource audio;
    public AudioClip gunEmptyAudio;
    public AudioClip gunReloadAudio;
    public AudioClip[] GunshotSounds;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        //timer = Time.time - Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > 0.2f)
        {
            if (roundCount > 0)
            {
                //Debug.Log("Shooting...");
                Instantiate((GameObject)Resources.Load("Prefabs/Bullet"), this.transform.position, this.transform.rotation);
                audio.clip = GunshotSounds[Random.Range(0, GunshotSounds.Length)];
                audio.Play();
                roundCount--;
                timer = 0;
            }
            else
            {
                //no bullets left
                //this.gameObject.AddComponent<AudioClip>();
                audio.clip = gunEmptyAudio;
                audio.Play();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //reloading
            audio.clip = gunReloadAudio;
            audio.Play();
            roundCount = 8;
        }
    }
}
