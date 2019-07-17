using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;
using WorkItemManagement.Models.Interfaces;

namespace WorkItemManagement.Models
{
    public class Board : IBoard
    {
        private string name;
        private ICollection<IActivity> listOfActivity;
        private ICollection<IWorkItem> listOfWorkItems;

        public Board(string name)
        {
            this.Name = name;
            this.listOfWorkItems = new List<IWorkItem>();
            this.listOfActivity = new List<IActivity>();
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
                    throw new ArgumentNullException("Name cannot be null or empty string.");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException($"The board's name should be between 5 and 10 symbols.");
                }

                this.name = value;
            }
        }

        public ICollection<IActivity> ListOfActivity
        {
            get
            {
                return new List<IActivity>(listOfActivity);
            }
        }

        public ICollection<IWorkItem> ListOfWorkItems
        {
            get
            {
                return new List<IWorkItem>(listOfWorkItems);
            }
        }

        public void AddBoardActivity(IActivity boardActivity)
        {
            if (boardActivity == null)
            {
                throw new ArgumentException("Activity hystory can not be null.");
            }

            this.listOfActivity.Add(boardActivity);
        }

        public void AddBoardWorkItem(IWorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentException("Work item can not be null.");
            }

            this.listOfWorkItems.Add(workItem);
        }

        public string ReturnBoardActivityToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"To board with name \"{this.Name}\" were made the following changes:");

            foreach (var activity in ListOfActivity)
            {
                sb.AppendLine($"On {activity.DateOfChange} : {activity.Description}");
            }

            return sb.ToString().Trim();
        }

        public string ReturnBoardWorkItemsToString(string workItemType)
        {
            var sb = new StringBuilder();

            foreach (var workItem in listOfWorkItems)
            {
                if (workItemType.ToLower() == workItem.GetType().Name.ToLower())
                {
                    sb.AppendLine(workItem.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string ReturnBoardWorkItemsToString()
        {
            var sb = new StringBuilder();

            foreach (var workItem in listOfWorkItems)
            {
                sb.AppendLine(workItem.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string ReturnBoardWorkItemsByStatusToString(string workItemStatus)
        {
            var sb = new StringBuilder();

            foreach (var workItem in this.listOfWorkItems)
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
