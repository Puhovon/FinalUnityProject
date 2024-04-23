﻿using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerView : MonoBehaviour
    {
        private const string isIdling = "IsIdling";
        private const string isRunning = "IsRunning";
        private Animator _animator;
        
        public void Initialize()
        {
            _animator = GetComponent<Animator>();
        }

        public void IdlingStop() => _animator.SetBool(isIdling, false);
        public void IdlingStart() => _animator.SetBool(isIdling, true);

        public void RunningStart() => _animator.SetBool(isRunning, true);
        public void RunningStop() => _animator.SetBool(isRunning, false);

    }
}