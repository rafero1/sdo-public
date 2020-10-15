using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


/**
 * Glaucoma.cs
 *
 * Script responsável pela renderização do filtro de Glaucoma.
 * Produz um efeito de visão periférica falha.
 */
public class Glaucoma : MonoBehaviour
{
	private Color color = Color.white;
	private int res = 51;
	private int indice = 0;

	public Image[] cataraca = new Image[5];
	public Slider sliderGlaucoma;
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
			SceneController.LoadDMRI(XRSettings.enabled);
		}
	}

	/**
	 * Altera valores de transparencia das texturas com base no valor especificado
	 */
	public void UpdateFilter(float value)
	{
		color.a = value / res;
		cataraca[0].color = color;

		color.a = value / 102;
		cataraca[1].color = color;

		color.a = value / 153;
		cataraca[2].color = color;

		color.a = value / 204;
		cataraca[3].color = color;

		color.a = value / 255;
		cataraca[4].color = color;
		color.a = 0.0f;
	}

	public void OnSliderChange()
	{
		filterValue = sliderGlaucoma.value;
		UpdateFilter(sliderGlaucoma.value);
	}

	//public void AlfaTexturas()
	//{
	//	if (sliderGlaucoma.value <= 52)
	//	{
	//		color.a = sliderGlaucoma.value / res;
	//		cataraca[0].color = color;
	//	}
	//	else if (sliderGlaucoma.value < 103)
	//	{
	//		color.a = sliderGlaucoma.value / 102;
	//		cataraca[1].color = color;
	//	}
	//
	//	switch (indice)
	//	{
	//		case 0:
	//			color.a = sliderGlaucoma.value / res;
	//			cataraca[0].color = color;
	//			break;
	//
	//		case 1:
	//			color.a = sliderGlaucoma.value / 102;
	//			cataraca[1].color = color;
	//			break;
	//	}
	//
	//	print(indice);
	//}
}
