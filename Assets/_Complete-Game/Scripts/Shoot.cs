﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.

namespace Completed
{
public class Shoot : MonoBehaviour {
    enum shootingDirection { UP, DOWN, LEFT, RIGHT };
    shootingDirection shoot;
    public GameObject bullet;
    public Vector2 velocity;
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
	public static int ammo;
	public Text ammoText;						//UI Text to display current player ammo total.

	// Use this for initialization
	void Start () {
        velocity = new Vector2(5f, 0f);
		cooldown = 0f;
	}
	
	// Update is called once per frame
    private void FixedUpdate()
    {
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

    private void Update()
    {
		ammoText.text = "Ammo: " + ammo;
		cooldown = cooldown - Time.deltaTime;
		if (ammo > 0) {
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
