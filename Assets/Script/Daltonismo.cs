using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


/**
 * Daltonismo.cs
 *
 * Script responsável pela renderização do filtro de Daltonismo.
 * Modifica as matrizes de cor da imagem.
 */
public class Daltonismo : MonoBehaviour
{
	// private Colorblind script;
	private Colorblind script;

    // Start is called before the first frame update
    void Start()
    {
		// script = Camera.main.GetComponent<Colorblind>();
		script = Camera.main.GetComponent<Colorblind>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonUp("B"))
		{
			if (script.enabled && script.blindness == Colorblind.Blindness.deuteranopia)
				script.enabled = false;
			else ToggleDeuteranopia();
		}

		if (Input.GetButtonUp("C"))
		{
			if (script.enabled && script.blindness == Colorblind.Blindness.tritanopia)
				script.enabled = false;
			else ToggleTritanopia();
		}

		if (Input.GetButtonUp("A"))
		{
			if (script.enabled && script.blindness == Colorblind.Blindness.protanopia)
				script.enabled = false;
			else ToggleProtanopia();
		}

		if (Input.GetButtonUp("D"))
		{
			SceneController.LoadGlaucoma(XRSettings.enabled);
		}
	}

	public void OnToggleType()
	{
		if (!script.enabled)
		{
			script.enabled = true;
			script.blindness = Colorblind.Blindness.deuteranopia;
		} else {
			switch (script.blindness)
			{
				case Colorblind.Blindness.deuteranopia:
					script.blindness = Colorblind.Blindness.protanopia;
					break;
				case Colorblind.Blindness.protanopia:
					script.blindness = Colorblind.Blindness.tritanopia;
					break;
				case Colorblind.Blindness.tritanopia:
					script.enabled = false;
					break;
			}
		}

	}

	public void ToggleNormal()
	{
		script.enabled = false;
	}

	public void ToggleProtanopia()
	{
		if (!script.enabled) script.enabled = true;
		script.blindness = Colorblind.Blindness.protanopia;
	}

	public void ToggleDeuteranopia()
	{
		if (!script.enabled) script.enabled = true;
		script.blindness = Colorblind.Blindness.deuteranopia;
	}

	public void ToggleTritanopia()
	{
		if (!script.enabled) script.enabled = true;
		script.blindness = Colorblind.Blindness.tritanopia;
	}
}
