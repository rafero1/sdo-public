using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.XR;


/**
 * Menu.cs
 *
 * Script para gerenciamento dos eventos que podem ser disparados no menu principal.
 */
public class Menu : MonoBehaviour
{
	private void Start() {
		XRSettings.enabled = false;
	}

	public void OnClickGlaucoma(bool loadAR = false)
	{
		SceneController.LoadGlaucoma(loadAR);
	}

	public void OnClickDMRI(bool loadAR = false)
	{
		SceneController.LoadDMRI(loadAR);
	}

	public void OnClickCatarata(bool loadAR = false)
	{
		SceneController.LoadCatarata(loadAR);
	}

	public void OnClickDaltonismo(bool loadAR = false)
	{
		SceneController.LoadDaltonismo(loadAR);
	}

	public void OnClickQuit()
	{
		SceneController.LoadMenu();
	}

}
