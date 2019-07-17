using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;

namespace WorkItemManagement.Models.Abstract
{
    public abstract class Task : WorkItem, ITask
    {
        public Task(string title, string description, PriorityType priorityType, IMember assignee)
           : base(title, description)
        {
            this.PriorityType = priorityType;
            this.Assignee = assignee;
        }

        public PriorityType PriorityType { get; protected set; }

        public IMember Assignee { get; protected set; }


        public void ChangePriority(PriorityType priorityType)
        {
            this.PriorityType = priorityType; 
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($" Priority: \"{this.PriorityType}\"");

            return sb.ToString().Trim();
        }

    }
}
