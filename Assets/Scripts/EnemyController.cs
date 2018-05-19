using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {

	public float boundX = 10.0f;

	public float speedX = 10.0f; 
    public float speedY = -1.0f;

	public float minShootingTime = 1f; 
    public float maxShootingTime = 3f;

	public float reloadTime = 0f;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	 void FixedUpdate() { 
        //Get the new position of our Enemy. On X, move left and right; on Y slowly get down. 
        var x = boundX * Mathf.Sin(Time.deltaTime * speedX); 
        var y = transform.position.y + Time.deltaTime * speedY;

		//Set a random reload time 
        reloadTime = Random.Range(minShootingTime, maxShootingTime);
 
        //Set the position of our character through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(x, y)); 
 
        // [...] 
    }
}
