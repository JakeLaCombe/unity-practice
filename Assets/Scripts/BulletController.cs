using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public float speed = 10.0f; 

    public float timeBeforeDestruction = 10.0f;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
 
        //Destroy the bullet if it didn't hit anything after 10 seconds 
        Destroy(gameObject, timeBeforeDestruction);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
