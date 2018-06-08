using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    public class DashMovement : MonoBehaviour
    {
        private SpriteRenderer mySpriteRenderer;
        float dashDistance = 2f;
        int dashFood = 5;
		Player player;

        // Use this for initialization
        void Start()
        {
			player = GetComponent<Player> ();
            mySpriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.doingSetup == false)
            {
                //If the player presses the key it will place the player 2 in front of the axis and deduct 5 food.
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.Translate(new Vector2(0, 1) * dashDistance);
                    if (transform.position.y > 7)
                    {
                        transform.position = new Vector2(transform.position.x, 7);
                    }
                    Player.food -= dashFood;
					player.CheckIfGameOver();
                    GameManager.instance.playersTurn = false;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.Translate(new Vector2(0, -1) * dashDistance);
                    if (transform.position.y < 0)
                    {
                        transform.position = new Vector2(transform.position.x, 0);
                    }
                    Player.food -= dashFood;
					player.CheckIfGameOver();
                    GameManager.instance.playersTurn = false;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.Translate(new Vector2(-1, 0) * dashDistance);
                    if (transform.position.x < 0)
                    {
                        transform.position = new Vector2(0, transform.position.y);
                    }
                    Player.food -= dashFood;
					player.CheckIfGameOver();
                    GameManager.instance.playersTurn = false;
                    mySpriteRenderer.flipX = true;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.Translate(new Vector2(1, 0) * dashDistance);
                    if (transform.position.x > 7)
                    {
                        transform.position = new Vector2(7, transform.position.y);
                    }
                    Player.food -= dashFood;
					player.CheckIfGameOver();
                    GameManager.instance.playersTurn = false;
                    mySpriteRenderer.flipX = false;
                }
                //Flip the sprite in the direction you move
                if(Input.GetKey(KeyCode.LeftArrow))
                {
                    mySpriteRenderer.flipX = true;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    mySpriteRenderer.flipX = false;
                }
            }
        }
    }
}
