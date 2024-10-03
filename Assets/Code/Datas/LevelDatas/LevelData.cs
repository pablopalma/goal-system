using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.LevelsSystem
{
    [CreateAssetMenu(fileName = "New Level Config", menuName = "Level System/Create New Level Config")]
    public class LevelData : ScriptableObject
    {
        public string levelName;
        public string levelDescription;
        public int levelBuildIndex;
        public List<GoalData> goalList;
        public List<AudioClip> backgroundMusics;
    }
}