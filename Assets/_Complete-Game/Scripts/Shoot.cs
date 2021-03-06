﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.Analytics;

namespace Completed
{
public class Shoot : MonoBehaviour {
    enum shootingDirection { UP, DOWN, LEFT, RIGHT }; //Sets the direction to shoot.
    shootingDirection shoot;
    public GameObject bullet; // Prefab of the bullet.
    public Vector2 velocity; // Speed of the bullet.
    bool canShoot = true;
    public Vector2 offset;
    public float coolDown = 1f;
    bool up = false;
    bool down = false;
    bool right = true;
    bool left = false;
	public AudioSource audioPlayer;
	public AudioClip clip;
	float cooldown;
	public static int ammo; //Amount of ammo.
	public Text ammoText;						//UI Text to display current player ammo total.
	int outOfAmmo = 1; //Out of Ammo.

	// Use this for initialization
	void Start () {
			//Sets the speed to shoot and direction.
        velocity = new Vector2(5f, 0f);
		cooldown = 0f;
	}
	
	// Update is called once per frame
    private void FixedUpdate()
    {
			//Checks which direction you are walking to see which direction to shoot and change speed.
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            velocity = new Vector2(0f, 5f);
            offset = new Vector2(0f, 0.8f);
            /*up = true;
            down = false;
            right = false;
            left = false;*/
            shoot = shootingDirection.UP;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            velocity = new Vector2(0f, -5f);
            offset = new Vector2(0f, -0.8f);
            /*up = false;
            down = true;
            right = false;
            left = false;*/
            shoot = shootingDirection.DOWN;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-5f, 0f);
            offset = new Vector2(-0.8f, 0f);
            /*up = false;
            down = false;
            right = false;
            left = true;*/
            shoot = shootingDirection.LEFT;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(5f, 0f);
            offset = new Vector2(0.8f, 0f);
            /*up = false;
            down = false;
            right = true;
            left = false;*/
            shoot = shootingDirection.RIGHT;
        }
    }
		//Checks if you still have ammo left to shoot and spawn the bullet. If you dont have ammo you cant shoot.
    private void Update()
    {
		ammoText.text = "Ammo: " + ammo;
		cooldown = cooldown - Time.deltaTime;
		if (ammo > 0) {
				outOfAmmo = 0;
			if (cooldown <= 0f) {
				if (Input.GetKeyDown (KeyCode.Space) && canShoot && shoot == shootingDirection.RIGHT) {
					GameObject go = (GameObject)Instantiate (bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

					go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y);
					audioPlayer.clip = clip;
					audioPlayer.Play ();
					Destroy (go.gameObject, 1.0f);
					cooldown = 1f;
					ammo -= 1;
				}
				if (Input.GetKeyDown (KeyCode.Space) && canShoot && shoot == shootingDirection.LEFT) {
					GameObject go = (GameObject)Instantiate (bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

					go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y);
					audioPlayer.clip = clip;
					audioPlayer.Play ();
					Destroy (go.gameObject, 1.0f);
					cooldown = 1f;
					ammo -= 1;
				}
				if (Input.GetKeyDown (KeyCode.Space) && canShoot && shoot == shootingDirection.UP) {
					GameObject go = (GameObject)Instantiate (bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

					go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y);
					audioPlayer.clip = clip;
					audioPlayer.Play ();
					Destroy (go.gameObject, 1.0f);
					cooldown = 1f;
					ammo -= 1;
				}
				if (Input.GetKeyDown (KeyCode.Space) && canShoot && shoot == shootingDirection.DOWN) {
					GameObject go = (GameObject)Instantiate (bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

					go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y);
					audioPlayer.clip = clip;
					audioPlayer.Play ();
					Destroy (go.gameObject, 1.0f);
					cooldown = 1f;
					ammo -= 1;
				}
			}
		}//If you are out of ammo send it to the analytics.
			if (ammo == 0 && outOfAmmo == 0) 
			{
				Analytics.CustomEvent ("Out of Ammo");
				Debug.Log ("Out of Ammo");
				outOfAmmo = 1;
			}
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
}
