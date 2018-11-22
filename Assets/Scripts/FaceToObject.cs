using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var destinationTransform = GameObject.Find("MixedRealityCamera").GetComponent<Transform>();

        this.GetComponent<GameObject>().transform.LookAt(destinationTransform);
	}
}
