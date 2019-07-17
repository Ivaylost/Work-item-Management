using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;
using WorkItemManagement.Models.Interfaces;

namespace WorkItemManagement.Models
{
    public class Member : IMember
    {
        private string name;
        private ICollection<IWorkItem> listOfMemberWorkItems;
        private ICollection<IActivity> listOfMemberActivity;

        public Member(string name)
        {
            this.Name = name;
            this.listOfMemberWorkItems = new List<IWorkItem>();
            this.listOfMemberActivity = new List<IActivity>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The members's name cannot be null or empty string.");
                }
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException($"The member's name should be between 5 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public ICollection<IActivity> ListOfMemberActivity
        {
            get
            {
                return new List<IActivity>(listOfMemberActivity);
            }
        }

        public ICollection<IWorkItem> ListOfMemberWorkItems
        {
            get
            {
                return new List<IWorkItem>(listOfMemberWorkItems);
            }
        }

        public void AddMemberActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("Activity hystory cannot be null");
            }

            this.listOfMemberActivity.Add(activity);
        }

        public void AssignMemberWorkItem(IWorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException("WorkItem activity history cannot be null");
            }

            this.listOfMemberWorkItems.Add(workItem);
        }

        public void UnAssignMemberWorkItem(IWorkItem workItem)
        {
            this.listOfMemberWorkItems.Remove(workItem);
        }

        public string ReturnMemberActivityToString()
        {
            var sb = new StringBuilder();

            foreach (var activity in listOfMemberActivity)
            {
                sb.AppendLine($"On {activity.DateOfChange} : {activity.Description}");
            }

            return sb.ToString().Trim();
        }

        public string ReturnMemberWorkItemsToString()
        {
            var sb = new StringBuilder();

            foreach (var workItem in listOfMemberWorkItems)
            {
                sb.AppendLine(workItem.ToString());
            }

            return sb.ToString();
        }

        public string ReturnMemberWorkItemsToString(string workItemType)
        {
            var sb = new StringBuilder();

            foreach (var workItem in listOfMemberWorkItems)
            {
                if (workItem.GetType().Name.ToLower() == workItemType.ToLower())
                {
                    sb.AppendLine(workItem.ToString());
                }
            }

            return sb.ToString();
        }

        public string ReturnMemberWorkItemsByStatusToString(string workItemStatus)
        {
            var sb = new StringBuilder();

            foreach (var workItem in listOfMemberWorkItems)
            {
                if (workItem is IBug)
                {
                    IBug bug = (IBug)workItem;

                    if (workItemStatus.ToLower() == "active" || workItemStatus.ToLower() == "fixed")
                    {
                        if (bug.StatusType == EnumHelper.GetStatusType(workItemStatus))
                        {
                            sb.AppendLine(workItem.ToString());
                        }

                    }

                }
                else if (workItem is IStory)
                {
                    IStory story = (IStory)workItem;

                    if (workItemStatus.ToLower() == "notdone" || workItemStatus.ToLower() == "inprogress" || workItemStatus.ToLower() == "done")
                    {
                        if (story.StatusType == EnumHelper.GetStoryStatusType(workItemStatus))
                        {
                            sb.AppendLine(workItem.ToString());
                        }
                    }

                }
                else if (workItem is IFeedback)
                {
                    IFeedback feedback = (IFeedback)workItem;

                    if (workItemStatus.ToLower() == "new" || workItemStatus.ToLower() == "unscheduled" ||
                        workItemStatus.ToLower() == "scheduled" || workItemStatus.ToLower() == "done")

                    {
                        if (feedback.StatusType == EnumHelper.GetFeedbackStatusType(workItemStatus))
                        {
                            sb.AppendLine(workItem.ToString());
                        }
                    }

                }
            }

            return sb.ToString().TrimEnd();
        }

    }
}
