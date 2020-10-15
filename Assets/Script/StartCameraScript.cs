using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * StartCameraScript.cs
 *
 * Script parente para os scripts que manipulam a camera.
 */
public class StartCameraScript : MonoBehaviour
{
    public virtual void ActivImageDisfigured()
    {
        Debug.Log("BaseClass StartCameraScript");
    }

    public virtual void OnClickQuit()
    {
        Debug.Log("BaseClass StartCameraScript");
    }
}
