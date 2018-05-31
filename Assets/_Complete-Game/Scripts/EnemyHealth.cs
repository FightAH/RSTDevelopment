using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed

{
    public class EnemyHealth : MonoBehaviour
    {

        public int enemyHealth = 4;
        public int attack = 1;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (enemyHealth == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Completed.Enemy.playerDamage = 0;
                attack = 0;
            }
            if(enemyHealth == 4)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Completed.Enemy.playerDamage = 20;
                attack = 1;
            }
        }
    }
}
