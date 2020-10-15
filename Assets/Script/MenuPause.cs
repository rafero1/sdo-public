using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuPause : MonoBehaviour
{

	private bool flagMenuStart;
	public Button btnScene;
	public Button btnExit;

	void Start()
	{
		btnScene.gameObject.SetActive(false);
		btnExit.gameObject.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			flagMenuStart = true;
		}

		if (flagMenuStart == false) {
			btnScene.gameObject.SetActive(false);
			btnExit.gameObject.SetActive(false);
		} else {
			btnScene.gameObject.SetActive(true);
			btnExit.gameObject.SetActive(true);
		}
	}

	public void OnClickQuit()
	{
		SceneController.LoadMenu();
	}

	public void OnClickScene()
	{
		flagMenuStart = false;
	}
}
