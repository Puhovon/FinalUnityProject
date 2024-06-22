﻿using Assets.Scripts.Global;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerDie : MonoBehaviour
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private Health _health;

        private void Constructor(Health playerHealth)
        {
            _health = playerHealth;
            _health.Die += () => Debug.Log("PlayerDie!");
        }

        private void Start()
        {
            _health.Die += () => Debug.Log("Player Die");
        }
    }
}