using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    public class DashMovement : MonoBehaviour
    {

        float dashDistance = 3f;
        int dashFood;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(new Vector2(0, 1) * dashDistance);
                Player.food -= 10;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(new Vector2(0, -1) * dashDistance);
                Player.food -= 10;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(new Vector2(1, 0) * dashDistance);
                Player.food -= 10;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-1, 0) * dashDistance);
                Player.food -= 10;
            }
        }
    }
}
