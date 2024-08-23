using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Global
{
    public class Achievements : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        
        private void Start()
        {
            int countOfShoots = PlayerPrefs.GetInt("Shoots");
            _text.text = $"Shoots: {countOfShoots}";
            _button.onClick.AddListener(GoToMainMenu);
        }

        private void GoToMainMenu()
        {
            PlayerPrefs.DeleteKey("Shoots");
            SceneManager.LoadScene("Lobby");
        }
    }
}