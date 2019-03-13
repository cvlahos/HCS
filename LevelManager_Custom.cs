using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager_Custom : MonoBehaviour {


	int totalLevels; //not used

	int currentLoadedLevel; // the level the player is currently playing

	public bool playTesting;
	public bool winScreen; //check if win screen
	public bool loseScreen; //check if lose screen
	public bool startScreen; //check if start screen
	public bool loadRandomLevel; //loads a random index from min to max

	public bool loadCustomLevel; //if checked then designer can type in the custom level name as a string
	public string customLevelToLoad; // holds the string level name

	public static int lastPlayedLevel; //holds index for the last played level in case the player want's to continue



	// Use this for initialization
	void Start () {

		//loadRandomLevel = true;
		playTesting = true;
		totalLevels = SceneManager.sceneCountInBuildSettings; //total levels in game for random level function
		currentLoadedLevel = SceneManager.GetActiveScene ().buildIndex; //storing current level to use in load next level


		//Debug.Log ("total levels in game - " + totalLevels);
		//Debug.Log ("current loaded level index - " + currentLoadedLevel);

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (playTesting) 
		{
			PlayTest ();
		}
	
	}

	public void LoadNextLevel()
	{
		int nextLevelToLoad = currentLoadedLevel + 1; //increments the crrentLoadedlevel index
		SceneManager.LoadScene (nextLevelToLoad);
	}

	public void LoadStartScreen()
	{
		SceneManager.LoadScene ("Start");
	}

	public void  CustomLoadLevel(string nameOfLevel)
	{
		Debug.Log ("load custom was checked");
		SceneManager.LoadScene (nameOfLevel);
	}

	public void LoadWinScreen()
	{
		SceneManager.LoadScene ("Win");
	}

	public void LoadLoseScreen()
	{
		lastPlayedLevel = currentLoadedLevel; // will store last played level that the player lost
		SceneManager.LoadScene ("Lose");
	}
		

	void PlayTest()
	{
		if (Input.GetKeyDown(KeyCode.L)) 
		{
			if (winScreen == true || loseScreen == true) 
			{
				LoadStartScreen ();
			} 

			else if (loadCustomLevel == true) 
			{
				CustomLoadLevel (customLevelToLoad);
			}

			else if (loadRandomLevel == true && startScreen != true && loseScreen != true && winScreen != true)
			{
				LoadRandomLevel (currentLoadedLevel);
			}

			else 
			{
				LoadNextLevel ();
			}

		}	

		if (Input.GetKeyDown (KeyCode.C) && loseScreen == true)
		{
			SceneManager.LoadScene (lastPlayedLevel);
		}
	}


	public void LoadRandomLevel(int loadIndex)
	{
		int rand = Random.Range (1, totalLevels - 2);

		while (rand == loadIndex) //loop will continue until the next random level isn't the same one that the player just finished
		{
			rand = Random.Range (1, totalLevels - 2);
		}
			
		SceneManager.LoadScene (rand);
	}

}



/* //bad recursive function
	public int LoadRandomLevel(int loadIndex)
	{
		int rand = Random.Range (1, totalLevels - 2);

		if (loadIndex == rand) 
		{
			LoadRandomLevel (loadIndex);
			return 0;
		} 
		else 
		{
			SceneManager.LoadScene (rand);
			return 0;
		}
	}
*/
