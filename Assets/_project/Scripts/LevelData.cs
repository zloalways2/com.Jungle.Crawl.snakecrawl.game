using System;

namespace _project.Scripts
{
    [Serializable]
    public sealed class LevelData
    {
        public float time = 60;
        public float rewardSpawnTime = 5f;
        public float tickTime = 0.5f;
        public float bombSpawnTime = 7f;
        public int index;
    }
}