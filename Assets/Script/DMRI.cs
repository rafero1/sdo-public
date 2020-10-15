using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


/**
 * DMRI.cs
 *
 * Script responsável pela renderização do filtro de DMRI.
 * Manipulação de brilho, distorção de imagem, efeito de desfoque e mancha central.
 *
 * Joystick (controles no modo Gaming - Segurar botão de switch (@) e apertar "B" / esquerda para entrar):
 * Botão da esquerda: "B" / 0
 * Botão de baixo: "D" / 1
 * Botão de cima: "C" / 2
 * Botão da direita: "A" / 3
 */
public class DMRI : MonoBehaviour
{
	private Color color = Color.white;
	private int currentFilter = 0;
	private StartCameraScript mainCameraScript;
	private BlurOptimized blurOptimized;
	private MeshFilter cameraTextureMesh;

	public Slider sliderBrilho;
	public Slider sliderMancha;
	public Image imgBrilho;
	public Image imgManchaPequena;
	public Image imgManchaGrande;
	public Mesh meshDefault;
	public Mesh meshDistorted;
	public GameObject cameraTexture;

	public float filterValueSpot = 0;
	public float filterValueBrightness = 0;

	void Start()
	{
		mainCameraScript = Camera.main.GetComponent<StartCameraScript>();
		blurOptimized = Camera.main.GetComponent<BlurOptimized>();
		cameraTextureMesh = cameraTexture.GetComponent<MeshFilter>();
	}

	void Update()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			if (currentFilter == 0)
			{
				filterValueSpot = Mathf.Clamp(filterValueSpot - 5, 0, 255);
				UpdateFilterSpot(filterValueSpot);
			}
			else
			{
				filterValueBrightness = Mathf.Clamp(filterValueBrightness - 5, 0, 255);
				UpdateFilterBrightness(filterValueBrightness);
			}
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			if (currentFilter == 0)
			{
				filterValueSpot = Mathf.Clamp(filterValueSpot + 5, 0, 255);
				UpdateFilterSpot(filterValueSpot);
			}
			else
			{
				filterValueBrightness = Mathf.Clamp(filterValueBrightness + 5, 0, 255);
				UpdateFilterBrightness(filterValueBrightness);
			}
		}

		if (Input.GetButtonUp("B"))
		{
			OnToggleBlur();
		}

		if (Input.GetButtonUp("C"))
		{
			OnToggleDistortion();
		}

		if (Input.GetButtonUp("A"))
		{
			if (currentFilter == 0) currentFilter = 1;
			else currentFilter = 0;
		}

		if (Input.GetButtonUp("D"))
		{
			SceneController.LoadCatarata(XRSettings.enabled);
		}
	}

	public void UpdateFilterSpot(float value)
	{
		color.a = value / 255;
		imgManchaPequena.color = color;
		color.a = value / 51;
		imgManchaGrande.color = color;
	}

	public void UpdateFilterBrightness(float value)
	{
		color.a = value / 255;
		imgBrilho.color = color;
	}

	public void OnChangeSliderSpot()
	{
		filterValueSpot = sliderMancha.value;
		UpdateFilterSpot(sliderMancha.value);
	}

	public void OnChangeSliderBrightness()
	{
		filterValueBrightness = sliderBrilho.value;
		UpdateFilterBrightness(sliderBrilho.value);
	}

	public void OnToggleBlur()
	{
		blurOptimized.enabled = !blurOptimized.enabled;
	}

	public void OnToggleDistortion()
	{
		mainCameraScript.ActivImageDisfigured();
		//cameraTextureMesh.mesh = meshDistorted;
	}
}
