using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


// Hi! This script presents the overlay info for our tutorial content, linking you back to the relevant page.

public class TutorialInfo : MonoBehaviour 
{
	//Which color is selected during the start menu.
	int colorSelected = 0;

	//Reference to the player object.
	public GameObject player;
	//Reference to the image.
	public GameObject image;
	//Reference to the SpriteRenderer of the image.
	public static SpriteRenderer m_SpriteRenderer;
	//Reference to the new color to be put on the player sprite.
	public static Color m_NewColor;
	//Reference to the gameManager.
    GameObject gameManager;

	// allow user to choose whether to show this menu 
	public bool showAtStart = true;

	// location that Visit Tutorial button sends the user
	public string url;

	// store the GameObject which renders the overlay info
	public GameObject overlay;

	// store a reference to the audio listener in the scene, allowing for muting of the scene during the overlay
	public AudioListener mainListener;

	// store a reference to the UI toggle which allows users to switch it off for future plays
	public Toggle showAtStartToggle;

	// string to store Prefs Key with name of preference for showing the overlay info
	public static string showAtStartPrefsKey = "showLaunchScreen";

	// used to ensure that the launch screen isn't more than once per play session if the project reloads the main scene
	private static bool alreadyShownThisSession = false;


	void Awake()
	{
		m_SpriteRenderer = player.GetComponent<SpriteRenderer>();
		// have we already shown this once?
		if(alreadyShownThisSession)
		{
			StartGame();
		}
		else
		{
			alreadyShownThisSession = true;

			// Check player prefs for show at start preference
			if (PlayerPrefs.HasKey(showAtStartPrefsKey))
			{
				showAtStart = PlayerPrefs.GetInt(showAtStartPrefsKey) == 1;
			}

			// set UI toggle to match the existing UI preference
			showAtStartToggle.isOn = showAtStart;

			// show the overlay info or continue to play the game
			if (showAtStart) 
			{
				ShowLaunchScreen();
			}
			else 
			{
				StartGame ();
			}	
		}
	}

	void Update()
	{
		//checks wich color is selected and changes the color of the sprite to that color.
		if (colorSelected == 0) 
		{
			m_NewColor = new Color(1, 1, 1);
			m_SpriteRenderer.color = m_NewColor;
			image.GetComponent<Image> ().color = m_NewColor;
		}
		if (colorSelected == 1) 
		{
			m_NewColor = new Color (0, 0, 1);
			m_SpriteRenderer.color = m_NewColor;
			image.GetComponent<Image> ().color = m_NewColor;
		}
		if (colorSelected == 2) 
		{
			m_NewColor = new Color (1, 0, 0);
			m_SpriteRenderer.color = m_NewColor;
			image.GetComponent<Image> ().color = m_NewColor;
		}
	}

	// show overlay info, pausing game time, disabling the audio listener 
	// and enabling the overlay info parent game object
	public void ShowLaunchScreen()
	{
		Time.timeScale = 0f;
		mainListener.enabled = false;
		overlay.SetActive (true);
	}

	// open the stored URL for this content in a web browser
	public void LaunchTutorial()
	{
        Application.Quit();
	}

	// continue to play, by ensuring the preference is set correctly, the overlay is not active, 
	// and that the audio listener is enabled, and time scale is 1 (normal)
	public void StartGame()
	{	
		Completed.GameManager.instance.gameStartTime = Time.time;	
		overlay.SetActive (false);
		mainListener.enabled = true;
		Time.timeScale = 1f;
	}

	// set the boolean storing show at start status to equal the UI toggle's status
	public void ToggleShowAtLaunch()
	{
		showAtStart = showAtStartToggle.isOn;
		PlayerPrefs.SetInt(showAtStartPrefsKey, showAtStart ? 1 : 0);
	}
    //Restarts the game, sets level back to 1, food o 100, shielded back to 0 and ammo back to 6.
	//Then reload the scene, find the gamemanager and puts it back to active.
    public void RestartGame()
    {
        Completed.GameManager.instance.level = 0;
        Completed.Player.food = 100;
		Completed.Player.shielded = 0;
		Completed.Shoot.ammo = 6;



        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        gameManager = GameObject.Find("GameManager(Clone)");
        gameManager.GetComponent<Completed.GameManager>().enabled = true;

    }
	//Lets you scroll between colors.
	public void Next()
	{
		if (colorSelected <= 2) 
		{
			colorSelected += 1;
			Debug.Log (colorSelected);
		}
	}
	//Lets you scroll between colors.
	public void Back()
	{
		if (colorSelected >= 0) 
		{
			colorSelected -= 1;
			Debug.Log (colorSelected);
		}
	}
}

