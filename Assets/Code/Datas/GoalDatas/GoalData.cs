using Assets.Code.GoalSystem;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Goal Config", menuName = "Goal System/Create New Goal Config")]
public class GoalData : ScriptableObject
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<ObjectiveData> Objectives => objectives;

    [SerializeField] private List<ObjectiveData> objectives;
}
