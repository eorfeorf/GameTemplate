using System;
using Game.Scripts.MusicScore;
using Game.Scripts.Note;
using UnityEngine;

namespace Game.Scripts.Stage
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] private NoteLoader noteLoader;
        
        private GameManager.GameManager gameManager;
        private Player.Player player;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager.GameManager>();
        }

        private void Start()
        {
            var musicScore = MusicScoreLoader.Load(0);
            var notes = noteLoader.Load(musicScore);
            player = new Player.Player(gameManager.InputEventProvider, notes);
        }
    }
}
