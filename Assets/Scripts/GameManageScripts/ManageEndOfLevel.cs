using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManageEndOfLevel : MonoBehaviour {

	private PlayerEnergy pe;
	private GameObject levelOverlay;
	private GameObject endOfLevelText;
	private GameObject gameOverText;
	private GameObject nextButton;

	void Awake(){
		pe = FindObjectOfType<PlayerEnergy> ();
		levelOverlay = GameObject.Find ("LevelOverlay");
		endOfLevelText = GameObject.Find ("EndOfLevelText");
		gameOverText = GameObject.Find ("GameOverText");
		nextButton = GameObject.Find ("NextButton");
		levelOverlay.SetActive (false);
	}

	void Update (){
		if (!pe.isAlive) {
			StartCoroutine (LoadGameOver());
		}
		if (pe.finished) {
			StartCoroutine (LoadEndScreen());
		}

	}

	private IEnumerator LoadGameOver (){
		yield return new WaitForSeconds(1.5f);
		levelOverlay.SetActive(true);
		endOfLevelText.SetActive(false);
		gameOverText.SetActive(true);
		nextButton.SetActive (false);
	}

	private IEnumerator LoadEndScreen (){
		yield return new WaitForSeconds(1.5f);
		levelOverlay.SetActive(true);
		endOfLevelText.SetActive(true);
		gameOverText.SetActive(false);
		nextButton.SetActive (true);
	}
}
