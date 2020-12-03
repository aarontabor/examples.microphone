using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BreathInputSensor : MonoBehaviour
{
    public string microphoneName;
    public Text forceLabel;
    public Slider forceSlider;

    private AudioClip clip;
    //private AudioSource audioSource;

    private float[] samples = new float[512];

    void Start()
    {
        foreach (string d in Microphone.devices) {
            Debug.Log(d);
        }
        clip = Microphone.Start(microphoneName, true, 1, 44100);

        /*
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        while (!(Microphone.GetPosition(microphoneName) > 0)) {}
        audioSource.Play();
        */
    }

    void Update()
    {
        clip.GetData(samples, 0);
        //audioSource.GetOutputData(samples, 0);
        
        float breathingForce = Mathf.Abs(samples.Average());
        forceLabel.text = breathingForce.ToString("0.000");
        forceSlider.value = breathingForce;
    }
}
