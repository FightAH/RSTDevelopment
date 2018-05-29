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
		
		Instantiate(explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
		GameObject go = GameObject.Find (name);
		Destroy (go.gameObject, 0.1f);
        Destroy(this.gameObject);

        if(col.gameObject.tag == "Enemy")
        {
			audioPlayer.clip = clip;
			audioPlayer.Play();
            Completed.EnemyHealth.enemyHealth -= 2;
            Debug.Log(Completed.EnemyHealth.enemyHealth);
        }
		if(col.gameObject.tag == "Tank")
		{
			audioPlayer.clip = clip;
			audioPlayer.Play();
			Completed.EnemyHealth.enemyHealth -= 1;
			Debug.Log(Completed.EnemyHealth.enemyHealth);
		}
    }
}
