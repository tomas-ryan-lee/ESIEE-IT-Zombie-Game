using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieSfx : MonoBehaviour {
    
    public AudioClip[] myClip;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().clip = myClip[Random.Range(0,myClip.Length)];
        GetComponent<AudioSource>().Play();
   
    }

}