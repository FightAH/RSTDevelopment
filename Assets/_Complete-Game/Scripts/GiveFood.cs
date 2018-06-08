using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.Analytics;

namespace Completed
{
public class GiveFood : MonoBehaviour {

	public static int giveFood = 1;
	int addFood;
	public Text giveFoodText;                     //Ui text to display what you consumed.

	// Use this for initialization
	void Start () {
			//Set starting variables values.
		giveFood = 1;
		giveFoodText.text = "";
		giveFoodText = GameObject.Find("GiveFoodText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//If you trigger the NPC, you will be prompted with text to accept food/
		//when you press e you will accept the food, he will give you a random amount of food bewteen 0 and 40.
		//Send the amount to the analytics.
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "NPC") 
		{
				
				if (giveFood == 1) 
				{
					giveFoodText.text = ("I have some food left if you want it take it. PRESS E TO TAKE FOOD");
					if (Input.GetKeyDown (KeyCode.E)) {
						Debug.Log ("Collided");
						addFood = Random.Range (0, 40);
						Completed.Player.food += addFood;
						Debug.Log ("Gave Food " + addFood);
						Analytics.CustomEvent ("Food Given", new Dictionary<string, object> 
							{
								{"addFood", addFood}
							}
						);
						giveFood = 0;
						giveFoodText.text = "";
					}
			}
		}
	}
}
}
