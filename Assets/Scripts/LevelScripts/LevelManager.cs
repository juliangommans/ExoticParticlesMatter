using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	
	public void LoadNewLevel (string name){
		SceneManager.LoadScene (name);
	}
}
