using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceUser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(Camera.main.transform.position);
        gameObject.transform.Rotate(-90, 180, 0);
    }
}
