using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Goal Config", menuName = "Goal System/Create New Goal Config")]

public class Goal : ScriptableObject
{
    public string name;
    public string description;
    public List<Objective> objectives;
    private bool _isGoalCompleted;

    public bool CheckGoalCompleted()
    {
        // How many objectives to complete?
        int completedAmount = 0;
        foreach (var objective in objectives) 
        {
            if (objective.IsCompleted)
            {
                completedAmount++;
            }
        }

        return _isGoalCompleted = (completedAmount == objectives.Count); 
    }
}
