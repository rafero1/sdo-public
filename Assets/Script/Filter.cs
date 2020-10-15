using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Filter : MonoBehaviour 
{

	public Color color = Color.white;
	public Image[] cataraca = new Image[4];
	private float sliderValue=0.0f;
	public GUISkin gui;
	
	public void Start ()
	{
		color.a=0.0f;
	}

	public void Update ()
	{
		ApplyFilter();
		//print(sliderValue);
	}

	private void ApplyFilter()
	{
		color.a+=sliderValue/2;
		cataraca[3].GetComponent<Image>().color = color;
		color.a=0.0f;

		color.a+=sliderValue/5;
		cataraca[4].GetComponent<Image>().color = color;
		color.a=0.0f;

		color.a+=sliderValue/20;
		cataraca[1].GetComponent<Image>().color = color;
		color.a=0.0f;

		color.a+=sliderValue/30;
		cataraca[2].GetComponent<Image>().color = color;
		color.a=0.0f;

		color.a+=sliderValue/35;
		cataraca[0].GetComponent<Image>().color = color;
		color.a=0.0f;
	}

	public void OnGUI()
	{
		GUI.skin = gui; 
		sliderValue = GUI.VerticalSlider(new Rect(10,10,100,500),sliderValue,0.0f,40.0f);
	}
}
