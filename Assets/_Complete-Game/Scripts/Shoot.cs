using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset = new Vector2(0.4f,0.1f);
    public float coolDown = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(transform.localScale.x == -1)
        {
            velocity = new Vector2(-5f,0f);
        }
        if (transform.localScale.x == 1)
        {
            velocity = new Vector2(5f, 0f);
        }
      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            GameObject go = (GameObject)Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);
            Destroy(go.gameObject, 1.0f);
        }

    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
