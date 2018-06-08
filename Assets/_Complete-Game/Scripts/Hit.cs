using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	public AudioSource audioPlayer;
	public AudioClip clip;
	public GameObject explosion;
	string name = "Explosion(Clone)";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D col)
    {
		//Intantiate an explosion on the location of the bullet impact, delete this explosion after 0.1 seconds/
		//If the collision is with an object of a certain tag do damage.
		Instantiate(explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
		GameObject go = GameObject.Find (name);
		Destroy (go.gameObject, 0.1f);
        Destroy(this.gameObject);

        if(col.gameObject.tag == "Enemy")
        {
			audioPlayer.clip = clip;
			audioPlayer.Play();
			col.gameObject.GetComponent<Completed.EnemyHealth>().enemyHealth -= 2;
        }
		if(col.gameObject.tag == "Tank")
		{
			audioPlayer.clip = clip;
			audioPlayer.Play();
			col.gameObject.GetComponent<Completed.EnemyHealth>().enemyHealth -= 1;
		}
    }
}
