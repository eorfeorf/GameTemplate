using Game.Scripts.MusicScore;
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Stage
{
    /// <summary>
    /// プレイするために準備するクラス
    /// </summary>
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
            //var musicScore = MusicScoreDownloader.Download(0);
            var musicScoreData = MusicScoreDataDownloader.Download(0);
            var notes = noteLoader.Load(gameManager, musicScoreData);
            player = new Player.Player(gameManager, notes);
            player.Play();
        }
    }
}