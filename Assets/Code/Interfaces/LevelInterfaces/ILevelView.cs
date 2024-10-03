namespace Assets.Code.LevelsSystem
{
    public interface ILevelView
    {
        void OnLevelCompleted();
        void UpdateLevelProgress(int currentGoals, int totalGoals);
        void ShowError(string message);
        void SetLevelCompletedWindowVisible(bool isVisible);
        void ResetView();
    }
}
