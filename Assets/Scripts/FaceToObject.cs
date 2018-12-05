using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var destinationTransform = Camera.main.transform;

        transform.LookAt(destinationTransform);
        transform.Rotate(-90, 180, 0);
    }
}
