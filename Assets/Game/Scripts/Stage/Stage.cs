using System;
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
    public class Stage
    {
        public Stage(GameContext.GameContext context, IInputEventProvider inputEventProvider, NoteLoader noteLoader, MeshFilter[] touchRangeMeshFilters)
        {
            var musicScoreData = MusicScoreDataDownloader.Download(0);
            var notes = noteLoader.Load(context, musicScoreData);
            var touchRanges = MeshFilterToRect(touchRangeMeshFilters);
            var player = new Player.Player(context, inputEventProvider, notes, touchRanges);
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