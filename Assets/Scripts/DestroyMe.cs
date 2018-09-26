using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {
	public float timeLive;

	// Use this for initialization
	void Start () {
		
		Destroy(gameObject, timeLive);
	}
	
	}

