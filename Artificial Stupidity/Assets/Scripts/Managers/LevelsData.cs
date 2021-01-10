using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelsData", order = 1)]
public class LevelsData : ScriptableObject
{
    [System.Serializable]
    public struct LevelData
    {
        public bool listened;
        public AudioClip audio;
        public LevelData(bool newListened, AudioClip newAudio)
        {
            listened = newListened;
            audio = newAudio;
        }
    }

    public List<LevelData> levels;
}
