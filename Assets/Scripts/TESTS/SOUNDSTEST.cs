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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _emitter.Play();
            print("AAAAAAAAAAAAAAA");
        }
    }
}
