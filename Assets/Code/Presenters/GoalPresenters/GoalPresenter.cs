using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.GoalSystem
{
    public class GoalPresenter
    {
        private IReadOnlyList<GoalData> _data;

        public GoalPresenter(IReadOnlyList<GoalData> data)
        {
            _data = data;
        }

        public bool CheckGoalCompleted()
        {
            return _data.SelectMany(g => g.Objectives).All(o => o.IsCompleted);
        }
    }

}
