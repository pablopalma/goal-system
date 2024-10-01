public class LevelPresenter
{
    private Level _level;
    private LevelView _levelView;

    public LevelPresenter(LevelView view, Level level)
    {
        _levelView = view;
        _level = level;
    }

    public void EnableNextLevel()
    {
        if (_level.IsLevelCompleted())
        {
            _levelView.OnLevelCompleted();
        }
    }

    public bool IsLevelCompleted()
    {
       return _level.IsLevelCompleted();
    }
}
