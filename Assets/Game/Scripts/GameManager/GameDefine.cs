namespace Game.Scripts.GameManager
{
    public static class GameDefine
    {
        #region Common
        public const float OneFrame = 1f / 60f;
        #endregion
        
        #region Note

        // public const float PERFECT_NEXT = OneFrame * 1;
        // public const float PERFECT_PREV = OneFrame * 0;

        public const float PERFECT_NEXT = OneFrame * 5;
        public const float PERFECT_PREV = OneFrame * 5;
        public const float GREAT_NEXT = OneFrame * 5;
        public const float GREAT_PREV = OneFrame * 5;
        public const float GOOD_NEXT = OneFrame * 5;
        public const float GOOD_PREV = OneFrame * 5;
        public const float BAD_NEXT = OneFrame * 5;
        public const float BAD_PREV = OneFrame * 5;
        #endregion
    }
}
