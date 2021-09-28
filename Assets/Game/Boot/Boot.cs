using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Boot
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private GameObject fader;

        private void Awake()
        {
            Instantiate(fader);
        }

        private void Start()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        }
    }
}
