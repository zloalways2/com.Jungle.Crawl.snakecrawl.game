using System;

namespace _project.Scripts
{
    [Serializable]
    public sealed class RocketGameLevelData
    {
        public float gameTime = 60;
        public float levelCoinsSpawnRate = 1f;
        public float gameCoinsMovementSpeed = 3f;
        public float coinsCollectionDistance = 0.5f;
        public int gameCoinScoreAddition = 5;
        public float gameShipMovementSpeed = 300f;
    }
}