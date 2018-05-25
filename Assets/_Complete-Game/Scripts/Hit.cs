using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);

        if(col.gameObject.tag == "Enemy")
        {
            Completed.EnemyHealth.enemyHealth -= 1;
            Debug.Log(Completed.EnemyHealth.enemyHealth);
        }
    }
}
