using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {
     Vector3 offset;
     
    public Transform target;
    public float smoothing = 5f;

    // Use this for initialization
    void Start () {
        offset = transform.position - target.position;
		
	}
    //private void Update()
    //{
    //    FixedUpdate();
    //}

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
