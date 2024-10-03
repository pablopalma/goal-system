using UnityEngine;

namespace Assets.Code.GoalSystem
{
    [CreateAssetMenu(fileName = "New Objective Config", menuName = "Goal System/Create New Objective Config")]
    public class ObjectiveData : ScriptableObject
    {
        [SerializeField] private bool _isGoalCompleted = false;
        
        public bool IsCompleted
        {
            get => _isGoalCompleted;
            set => _isGoalCompleted = value;
        }
        public string objectiveName;
        public string objectiveDescription;
    }
}