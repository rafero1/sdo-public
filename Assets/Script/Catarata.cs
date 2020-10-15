using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


/**
 * Catarata.cs
 *
 * Script responsável pela renderização do filtro de Catarata.
 * Modifica o brilho da imagem.
 */
public class Catarata : MonoBehaviour
{
	private Color color = Color.white;

	public Slider sliderBrilho;
	public Image imgBrilho;
	public float filterValue = 0;

	void Start()
	{
		//
	}

	void Update()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			filterValue = Mathf.Clamp(filterValue - 5, 0, 255);
			UpdateFilter(filterValue);
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			filterValue = Mathf.Clamp(filterValue + 5, 0, 255);
			UpdateFilter(filterValue);
		}

		if (Input.GetButtonUp("D"))
		{
			SceneController.LoadDaltonismo(XRSettings.enabled);
		}
	}

	public void OnSliderChange()
	{
		filterValue = sliderBrilho.value;
		UpdateFilter(sliderBrilho.value);
	}

	public void UpdateFilter(float value)
	{
		color.a = value / 255;
		imgBrilho.color = color;
	}
}
