using UnityEngine.Events;

namespace Assets.Code.GoalSystem
{
    public class ObjectivePresenter
    {
        private ObjectiveData _data;
        private IObjectiveView _view;
        public UnityEvent OnCompleted;

        public ObjectivePresenter(IObjectiveView view, ObjectiveData data)
        {
            _data = data;
            _view = view;
            OnCompleted = new UnityEvent();
            _data.IsCompleted = false;
        }

        public void Complete()
        {
            _data.IsCompleted = true;
            OnCompleted.Invoke();
            _view.OnObjectiveCompleted();
        }
    }

}
