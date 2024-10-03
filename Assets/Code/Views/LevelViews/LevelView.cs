using Assets.Code.GoalSystem;
using Assets.Code.LevelsSystem;
using UnityEngine;

public class LevelView : MonoBehaviour, ILevelView
{
    public LevelData level;

    [SerializeField] private GameObject _levelCompletedWindow;

    private LevelPresenter _presenter;
    private GoalPresenter _goalPresenter;
  

    private void Awake()
    {
        _goalPresenter = new GoalPresenter(level.goalList);
        _presenter = new LevelPresenter(this, level, _goalPresenter);
    }

    public void OnLevelCompleted()
    {
        _levelCompletedWindow.SetActive(true);
    }

    public void CheckLevelStatus()
    {
        if (_presenter.IsLevelCompleted())
        {
            _levelCompletedWindow.SetActive(true);
        }
    }

    public void UpdateLevelProgress(int currentGoals, int totalGoals)
    {
    }

    public void ShowError(string message)
    {
    }

    public void SetLevelCompletedWindowVisible(bool isVisible)
    {
    }

    public void ResetView()
    {
    }
}