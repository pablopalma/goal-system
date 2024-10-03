using Assets.Code.Datas.ItemDatas;

namespace Assets.Code.GoalSystem
{
    public class ObjectiveView : Objective, IInteractable, IObjectiveView
    {
        public ItemData itemConfig;

        private void Awake()
        {
            _presenter = new ObjectivePresenter(this, objective);
        }

        public void Complete()
        {
            _presenter.Complete();
        }

        public void Interact()
        {
            Complete();
        }

        public void OnObjectiveCompleted()
        {
            
        }
    }
}