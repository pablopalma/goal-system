using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Config", menuName = "Level System/Create New Level Config")]
public class Level : ScriptableObject
{
    public string levelName;
    public string levelDescription;
    public int levelBuildIndex;
    public List<Goal> goalList;
    public List<AudioClip> backgroundMusics;

    public bool IsLevelCompleted()
    {
        // How many goals to complete?
        int goalsAmount = 0;

        foreach (Goal goal in goalList)
        {
            if (goal.CheckGoalCompleted())
            {
                goalsAmount++;
            }
        }


        return goalsAmount == goalList.Count;
    }
}
