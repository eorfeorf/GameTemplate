using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.MusicScore;
using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Stage
{
    [Serializable]
    struct TouchRanges
    {
        public Plane[] ranges;
    }
    
    /// <summary>
    /// プレイするために準備するクラス
    /// </summary>
    public class Stage : MonoBehaviour
    {
        [SerializeField] private NoteLoader noteLoader;
        
        //[SerializeField] private TouchRanges touchRanges;
        [SerializeField] private MeshFilter[] touchRangeMeshFilters;
        
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
            var touchRanges = MeshFilterToRect(this.touchRangeMeshFilters);
            player = new Player.Player(gameManager, notes, touchRanges);
            player.Play();
        }

        private static Rect[] MeshFilterToRect(MeshFilter[] meshFilters)
        {
            return meshFilters.Select(mf =>
            {
                // TODO:Verticesはローカル座標
                var v0 = Camera.main.WorldToScreenPoint(mf.mesh.vertices[0]);
                var v1 = Camera.main.WorldToScreenPoint(mf.mesh.vertices[3]);
                return new Rect {xMin = v0.x, yMin = v0.y, xMax = v1.x, yMax = v1.y};
            }).ToArray();
        }
    }
}