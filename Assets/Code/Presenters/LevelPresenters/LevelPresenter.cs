using Assets.Code.GoalSystem;
using Assets.Code.LevelsSystem;

public class LevelPresenter
{
    private LevelData _levelData;
    private LevelView _levelView;
    private GoalPresenter _goalPresenter;

    public LevelPresenter(LevelView view, LevelData level, GoalPresenter goalPresenter)
    {
        _levelView = view;
        _levelData = level;
        _goalPresenter = goalPresenter;
    }

    public void EnableNextLevel()
    {
        if (_goalPresenter.CheckGoalCompleted())
        {
            _levelView.OnLevelCompleted();
        }
    }

    public bool IsLevelCompleted()
    {
       return _goalPresenter.CheckGoalCompleted();
    }
}
