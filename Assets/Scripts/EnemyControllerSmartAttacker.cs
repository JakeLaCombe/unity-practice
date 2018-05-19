using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerSmartAttacker : MonoBehaviour {
	public float boundX = 1.0f;

	public float speedX = 1.0f; 
    public float speedY = -0.01f;

	public float minShootingTime = 1f; 
    public float maxShootingTime = 3f;

	public float reloadTime = 0f;

	private Rigidbody2D rigidBody;
	public GameObject bulletPrefab;
	private Transform playerTransform; 
	public float shootSensitivity = 0.1f;
	private float lastTimeShot = 0f; 

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		playerTransform = FindObjectOfType<PlayerController>().transform; 
	}
	
	 void FixedUpdate() { 
        //Get the new position of our Enemy. On X, move left and right; on Y slowly get down. 
        var x = boundX * Mathf.Sin(Time.time / 6f * speedX); 
        var y = transform.position.y + Time.deltaTime * speedY;

		if(Time.time - lastTimeShot > reloadTime) { 
			//Check if the enemy is "close" on the x-axis to the player 
			if (Mathf.Abs(playerTransform.position.x - transform.position.x) < shootSensitivity) { 
				//Set the current time as the last time the spaceship has fired 
				lastTimeShot = Time.time; 

				//Set a random reload time 
        		reloadTime = Random.Range(minShootingTime, maxShootingTime);

				//Create the bullet 
				Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
			} 
		}

        //Set the position of our character through the RigidBody2D component (since we are using physics) 
        rigidBody.MovePosition(new Vector2(x, y)); 
 
        // [...] 
    }
}
