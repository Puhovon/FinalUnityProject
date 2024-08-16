using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class SOUNDSTEST : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    void Start()
    {
        _emitter = FindObjectOfType<StudioEventEmitter>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _emitter.Play();
    }
}
