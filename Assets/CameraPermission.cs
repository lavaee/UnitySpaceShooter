using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class CameraPermission : MonoBehaviour
{
    public Renderer renderer;
    public RawImage raw;
    public int index;

    static WebCamTexture webCam;

    void Start()
    {
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            print(WebCamTexture.devices[i].name);
        }

        {
            //if (webCam == null)
            //{
            //    webCam = new WebCamTexture();
            //}

            //print(webCam.deviceName);
            //print(webCam.graphicsFormat);
            //print(webCam.isReadable);
            //print(webCam.name);

            //renderer.material.mainTexture = webCam;
            //raw.texture = webCam;

            //if (!webCam.isPlaying)
            //{
            //    webCam.Play();
            //}
        }
    }

    void Update()
    {

    }

    public void StartStopCam()
    {
        if (webCam != null)
        {
            renderer.material.mainTexture = null;
            raw.texture = null;
            webCam.Stop();
            webCam = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[index];
            webCam = new WebCamTexture(device.name);
            renderer.material.mainTexture = webCam;
            raw.texture = webCam;
            webCam.Play();
        }
    }
}
