using System;
using TMPro;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public class ComboView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;

        public void SetActive(bool active) => text.gameObject.SetActive(active);
        
        private void Start()
        {
            text.text = "";
        }

        public void SetCombo(int combo)
        {
            text.text = combo.ToString();
        }
    }
}
