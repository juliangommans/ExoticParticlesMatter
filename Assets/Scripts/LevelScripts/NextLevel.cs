using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : LevelManager {

	private int currentLevel;
	private string levelString;

	void Awake(){
		currentLevel = FindObjectOfType<ManageLevelChanges> ().currentLevel;
		if (currentLevel >= 9){
			levelString = "Level";
		} else {
			levelString = "Level0";
		}
	}

	public void LoadNextLevel(){
		LoadNewLevel ( levelString + (currentLevel + 1));
	}

}
