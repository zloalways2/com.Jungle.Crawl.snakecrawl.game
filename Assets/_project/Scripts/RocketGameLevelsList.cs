using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _project.Scripts
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Game/Levels", order = 0)]
    public sealed class RocketGameLevelsList : ScriptableObject
    {
       [FormerlySerializedAs("levels")] [SerializeField] private List<LevelData> rocketLevels = new List<LevelData>();

        public IReadOnlyList<LevelData> GameRocketLevels => rocketLevels;
    }
}