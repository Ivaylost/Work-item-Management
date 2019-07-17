using WorkItemManagement.Enums;

namespace WorkItemManagement.Contracts
{
    public interface ITask : IWorkItem
    {
        PriorityType PriorityType { get; }

        IMember Assignee { get; }

        void ChangePriority(PriorityType priorityType);

    }
}
