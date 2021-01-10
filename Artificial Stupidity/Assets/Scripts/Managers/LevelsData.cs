using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelsData", order = 1)]
public class LevelsData : ScriptableObject
{
    [System.Serializable]
    public struct LevelData
    {
        public bool started;
    }

    public List<LevelData> levels;

    private void Awake()
    {
        levels = new List<LevelData>();
    }
}
