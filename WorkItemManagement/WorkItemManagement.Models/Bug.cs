using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;
using WorkItemManagement.Models.Abstract;

namespace WorkItemManagement.Models.WorkItems
{
    public class Bug : Task, IBug, ITask, IWorkItem
    {
        private ICollection<string> stepsToReproduce;

        public Bug(string title, string description, ICollection<string> stepsToReproduce,
                    PriorityType priorityType, BugSeverityType bugSeverityType, 
                    BugStatusType bugStatusType, IMember assignee)
                  : base(title, description, priorityType, assignee)
        {
            this.stepsToReproduce = new List<string>(stepsToReproduce);
            this.PriorityType = priorityType;
            this.SeverityType = bugSeverityType;
            this.StatusType = bugStatusType;
        }

        public BugSeverityType SeverityType { get; private set; }

        public BugStatusType StatusType { get; private set ; }

        public ICollection<string> StepsToReproduce
        {
            get
            {
                return new List<string>(this.stepsToReproduce);
            }
        }

        public void ChangeSeverity(BugSeverityType bugSeverityType)
        {
            this.SeverityType = bugSeverityType;
        }

        public void ChangeStatus(BugStatusType bugStatusType)
        {
            this.StatusType = bugStatusType;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Step to reproduce: {string.Join(" ", stepsToReproduce)}");
            sb.AppendLine($" Severity: \"{this.SeverityType}\"");
            sb.AppendLine($" Status: \"{this.StatusType}\"");
            sb.AppendLine($" Assignee: \"{this.Assignee.Name}\"");

            if (ListOfComments.Count > 0)
            {
                foreach (var comment in listOfComments)
                {
                    sb.AppendLine($" Comment author: \"{comment.Author.Name}\"");
                    sb.AppendLine($" Message: \"{comment.Message}\"");
                }
            }
           
            return sb.ToString().Trim();
        }

    }
}
