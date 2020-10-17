using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


/**
 * StartCamera.cs
 *
 * Script responsável pela captura e renderização da camera do dispositivo.
 */
public class StartCamera : StartCameraScript
{
    private WebCamDevice webCamDevice;
	private WebCamTexture webCamTexture = null;
	private bool flagSliderActivtScreenRight;
	private int sizeScreenWidth;
	private float timeScreen = 5;
	private bool flagMenuStart;
	private Touch touch;
    private Quaternion baseRotation;
    private Vector3 baseScale;

	public string camName;
	public GameObject textureCam;
	public GameObject imageDisfigured;
	public GameObject panelUI;
	public bool enableCardboard;

	IEnumerator LoadDevice(string newDevice, bool enabled)
	{
		XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		XRSettings.enabled = enabled;
	}

	void EnableVR()
	{
		StartCoroutine(LoadDevice("Cardboard", true));
	}

	void DisableVR()
	{
		StartCoroutine(LoadDevice("", false));
	}

    void Start()
	{
		if (enableCardboard && XRSettings.enabled == false) EnableVR();
		if (!enableCardboard && XRSettings.enabled) DisableVR();

        baseRotation = transform.rotation;
        baseScale = textureCam.transform.localScale;

        webCamTexture = new WebCamTexture(Screen.width/2, Screen.height/2, 30);
		webCamTexture.filterMode = FilterMode.Trilinear;
		textureCam.GetComponent<Renderer>().material.mainTexture = webCamTexture;

		if (imageDisfigured != null)
		{
            imageDisfigured.GetComponent<Renderer>().material.mainTexture = webCamTexture;
		}

        foreach (WebCamDevice d in WebCamTexture.devices)
		{
            if ((string.IsNullOrEmpty(camName) || d.name == camName) && !d.isFrontFacing)
			{
                webCamDevice = d;
                webCamTexture.deviceName = d.name;
                webCamTexture.Play();
                Flip();
            }
        }

		if (panelUI != null)
		panelUI.gameObject.SetActive (false);

		// Capturar o tamanho da tela
		sizeScreenWidth = Screen.width;

		touch = new Touch();
	}

	void Update()
	{
		ItCalculatesTimeScreen ();

		//Verifica se pode ativar o slider da Direita
		if (Input.GetMouseButton(0))
		{
			timeScreen = 0;
			if (!flagSliderActivtScreenRight && !flagMenuStart)
			{
				panelUI.gameObject.SetActive(true);
				flagSliderActivtScreenRight=true;
			}
		}

		// Ao apertar no "X" da visão cardboard
		if (Input.GetKey(KeyCode.Escape))
		{
			OnClickQuit();
		}
	}

	public void OnClickScene()
	{
		flagMenuStart = false;
	}

	override public void OnClickQuit()
	{
		if (enableCardboard) DisableVR();
		webCamTexture.Stop();
		SceneController.LoadMenu();
	}

	void ItCalculatesTimeScreen()
	{

		if(timeScreen < 4)
		{
			timeScreen += Time.deltaTime;
		}
		else
		{
			if (flagSliderActivtScreenRight)
			{
				panelUI.gameObject.SetActive(false);
				flagSliderActivtScreenRight=false;
			}
		}
	}

	override public void ActivImageDisfigured()
	{
		if (!imageDisfigured.gameObject.activeSelf)
		{
			imageDisfigured.gameObject.SetActive (true);
			textureCam.gameObject.SetActive (false);
		}
		else
		{
			imageDisfigured.gameObject.SetActive (false);
			textureCam.gameObject.SetActive (true);
		}
	}

    private void Flip()
	{
        textureCam.transform.localScale = baseScale;

        int flipCode = int.MinValue;

        if (webCamDevice.isFrontFacing)
		{
            if (webCamTexture.videoRotationAngle == 0 || webCamTexture.videoRotationAngle == 90)
			{
                flipCode = 1;
            }
			else if (webCamTexture.videoRotationAngle == 180 || webCamTexture.videoRotationAngle == 270)
			{
                flipCode = 0;
            }
        }
		else
		{
            if (webCamTexture.videoRotationAngle == 180 || webCamTexture.videoRotationAngle == 270)
			{
                flipCode = -1;
            }
        }

        if (flipCode > int.MinValue)
		{
            Vector3 s = textureCam.transform.localScale;
            textureCam.transform.localScale = flipCode == 0 ? new Vector3(s.x, s.y, s.z * -1) : flipCode == 1 ? new Vector3(s.x * -1, s.y, s.z) : new Vector3(s.x * -1, s.y, s.z * -1);
        }
    }
}
