using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.XR;


public class SceneController
{
	public static void LoadGlaucoma(bool loadAR = false)
	{
		if (loadAR)
			SceneManager.LoadScene(2);
		else
			SceneManager.LoadScene(1);
	}

	public static void LoadDMRI(bool loadAR = false)
	{
		if (loadAR)
			SceneManager.LoadScene(4);
		else
			SceneManager.LoadScene(3);
	}

	public static void LoadCatarata(bool loadAR = false)
	{
		if (loadAR)
			SceneManager.LoadScene(6);
		else
			SceneManager.LoadScene(5);
	}

	public static void LoadDaltonismo(bool loadAR = false)
	{
		if (loadAR)
			SceneManager.LoadScene(8);
		else
			SceneManager.LoadScene(7);
	}

	public static void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}
}
