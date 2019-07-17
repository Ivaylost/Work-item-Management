using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;
using WorkItemManagement.Models.Abstract;

namespace WorkItemManagement.Models.WorkItems
{
    public class FeedBack : WorkItem, IFeedback
    {
        public FeedBack(string title, string description, int rating,
                       FeedbackStatusType feedbackStatusType) 
                       : base(title, description)
        {
            this.Rating = rating;
            this.StatusType = feedbackStatusType;
        }

        public int Rating { get; set; }
        
        public FeedbackStatusType StatusType { get; private set; }

        public void ChangeRating(int rating)
        {
            this.Rating = rating;
        }

        public void ChangeStatus(FeedbackStatusType feedbackStatusType)
        {
            this.StatusType = feedbackStatusType;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Status: \"{this.StatusType}\"");
            sb.AppendLine($" Rating: \"{this.Rating}\"");

            return sb.ToString().TrimEnd();
        }
    }
}
