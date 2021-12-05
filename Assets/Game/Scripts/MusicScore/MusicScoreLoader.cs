namespace Game.Scripts.MusicScore
{
    public static class MusicScoreLoader
    {
        public static MusicScore Load(int musicScoreId)
        {
            // IDから譜面のデータを引っ張ってくる.
            MusicScore musicScore = default;
            switch (musicScoreId)
            {
                case 0:
                    musicScore = new MusicScore();
                    break;
            }

            return musicScore;
        }
    }
}
