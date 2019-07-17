using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;
using WorkItemManagement.Models.Abstract;

namespace WorkItemManagement.Models.WorkItems
{
    public class Story : Task, IStory,  ITask, IWorkItem
    {
        public Story(string title, string description, 
                     PriorityType priorityType, StorySizeType storySizeType,
                     StoryStatusType storyStatusType, IMember assignee)
            : base(title, description, priorityType, assignee)
        {
            this.SizeType = storySizeType;
            this.StatusType = storyStatusType;
        }

        public StorySizeType SizeType { get; private set; }

        public StoryStatusType StatusType { get; private set; }

        public void ChangeSize(StorySizeType storySizeType)
        {
            this.SizeType = storySizeType;
        }

        public void ChangeStatus(StoryStatusType storyStatusType)
        {
            this.StatusType = storyStatusType;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Size: \"{this.SizeType}\"");
            sb.AppendLine($" Status: \"{this.StatusType}\"");
            sb.AppendLine($" Assignee: \"{this.Assignee.Name}\"");

            if (listOfComments.Count > 0)
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
