using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.SetPositionAndRotation(new Vector3(target.position.x, target.position.y, -10), Quaternion.identity);

    }
}
