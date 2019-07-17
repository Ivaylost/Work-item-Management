using System.Collections.Generic;
using WorkItemManagement.Contracts;
using WorkItemManagement.Enums;
using WorkItemManagement.Models;
using WorkItemManagement.Models.Interfaces;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Core.Factories
{
    public class WIMFactory
    {
        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }

        public IBug
            CreateBug(string title, string description, ICollection<string> stepsToReproduce, PriorityType priorityType,
                   BugSeverityType bugSeverityType, BugStatusType bugStatusType, IMember assignee)
        {
            return new Bug(title, description, stepsToReproduce, priorityType,
                bugSeverityType, bugStatusType, assignee);
        }

        public IStory CreateStory(string title, string description,
                     PriorityType priorityType, StorySizeType storySizeType,
                     StoryStatusType storyStatusType, IMember assignee)
        {
            return new Story(title, description, priorityType, storySizeType, storyStatusType, assignee);
        }

        public IFeedback CreateFeedback(string title, string description, int rating,
                       FeedbackStatusType feedbackStatusType)
        {
            return new FeedBack(title, description, rating, feedbackStatusType);
        }

        public IActivity CreateActivity(string description, IMember maker)
        {
            return new Activity(description, maker);
        }

        public IActivity CreateActivity(string description)
        {
            return new Activity(description);
        }

        public IComment CreateComment(string message, IMember author)
        {
            return new Comment(message, author);
        }
    }
}
