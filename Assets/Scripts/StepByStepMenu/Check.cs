using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
    public Texture frame;
    private int framesPerSecond = 10;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //int index = (int)((Time.time * framesPerSecond) % frames.Length);
        //GetComponent<Renderer>().material.mainTexture = frame[index];
    }
}
