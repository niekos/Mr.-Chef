using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToObject : MonoBehaviour {

    public bool Correction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var destinationTransform = Camera.main.transform;

        transform.LookAt(destinationTransform);
        if (Correction)
        {
            transform.Rotate(-90, 180, 0);
        }
        else
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
