using UnityEngine;

namespace Assets.Code.GoalSystem
{
    public abstract class Objective : MonoBehaviour
    {
        [SerializeField] protected ObjectivePresenter _presenter;
        [SerializeField] protected ObjectiveData objective;
    }
}
