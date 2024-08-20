using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Bus : MonoBehaviour
{
    private FMOD.Studio.Bus sound;
    private FMOD.Studio.Bus musik;

    [SerializeField, Range(-80f, 10f)] private float busVolume;
    
    private void Start()
    {
        sound = RuntimeManager.GetBus("bus:/Bus");
        musik = RuntimeManager.GetBus("bus:/Musik");
    }

    public float GetSoundsVolume()
    {
        sound.getVolume(out float v);
        return v;
    }

    public float GetMusikVolume()
    {
        musik.getVolume(out float v);
        return v;
    }
    public void SetSoundsVolume(float volume)
    {
        sound.setVolume(DecibelToLinear(volume));
    }

    public void SetMusikVolume(float volume)
    {
        musik.setVolume(DecibelToLinear(volume));
    }
    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20);
        return linear;
    }
}
