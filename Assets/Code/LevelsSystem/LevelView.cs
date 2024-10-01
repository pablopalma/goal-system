using UnityEngine;

public class LevelView : MonoBehaviour
{
    private LevelPresenter _presenter;
    public Level level;
    [SerializeField] private GameObject _levelCompletedWindow;

    private void Awake()
    {
        _presenter = new LevelPresenter(this, level);
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
}