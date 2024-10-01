using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Config", menuName = "Goal System/Create New Objective Config")]
public class Objective : ScriptableObject
{
    public bool IsCompleted => _isGoalCompleted;
    public string objectiveName;
    public string objectiveDescription;
    [SerializeField] private bool _isGoalCompleted = false;

    public void Complete()
    {
        _isGoalCompleted = true;
    }
}
