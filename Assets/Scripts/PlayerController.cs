using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour {

	private float speed = 3.0f;
	private Rigidbody2D rigidBody;
	public float boundX = 10.0f;
	public GameObject bulletPrefab;
	public GameObject explosionPrefab;
	public float reloadTime = 1.0f; 
    private float lastTimeShot = 0f; 

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Hit(Vector3 hitCoordinates) { 
        //Create an explosion on the coordinates of the hit. 
        Instantiate(explosionPrefab, hitCoordinates, Quaternion.identity); 
    } 

	void FixedUpdate() {
        //Get the new position of our character
        var x = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
 
        //Set the position of our character through the RigidBody2D component (since we are using physics)
        rigidBody.MovePosition(new Vector2(Mathf.Clamp(x, -boundX, boundX), transform.position.y));

		// Remove this later
		if (Input.GetKeyDown(KeyCode.T)) { 
            Hit(transform.position); 
        } 

		 //Check if the player has fired 
        if (Input.GetKeyDown(KeyCode.E)) { 
			
             //Check if the player can shoot since last time the spaceship has fired 
            if(Time.time - lastTimeShot > reloadTime) { 
                //Set the current time as the last time the spaceship has fired 
                lastTimeShot = Time.time; 
 
                //Create the bullet 
                Rigidbody2D tempVelocity = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>(); 
				tempVelocity.velocity = new Vector2(0.0f, 1.0f);
            } 
        } 
    }
}
