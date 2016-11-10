using UnityEngine;
using System.Collections;

public class CallCamra : MonoBehaviour
{

    private WebCamTexture _camTexture;
    public GameObject Bg;
    void Start()
    {
        StartCoroutine(OpenDevice());
    }


    IEnumerator OpenDevice()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length >= 1)
            {
                string deviceName = devices[0].name;

                _camTexture = new WebCamTexture(deviceName, 300, 400, 15);
                _camTexture.Play();

            }
        }
    }

    void Update()
    {
        if (_camTexture && _camTexture.isPlaying)
        {
            Bg.GetComponent<Renderer>().material.mainTexture = _camTexture;
        }
    }

    void OnGUI()
    {
        if (_camTexture && _camTexture.isPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, 100, 80), _camTexture, ScaleMode.ScaleToFit);
        }
        if (GUILayout.Button("play"))
        {

            if (_camTexture)
                _camTexture.Play();
        }
        if (GUILayout.Button("pause"))
        {

            if (_camTexture)
                _camTexture.Pause();
        }
        if (GUILayout.Button("stop"))
        {
            if (_camTexture)
                _camTexture.Stop();
        }
    }
}
