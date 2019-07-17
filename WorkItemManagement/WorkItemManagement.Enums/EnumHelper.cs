using System;

namespace WorkItemManagement.Enums
{
    public static class EnumHelper
    {
        private const string InvalidPriorityType = "Invalid priority type!";
        private const string InvalidStatusType = "Invalid status type!";
        private const string InvalidSizeType = "Invalid size type!";
        private const string InvalidSeverityType = "Invalid severity type!";

        public static PriorityType GetPriorityType(string priorityType)
        {
            switch (priorityType.ToLower())
            {
                case "high":
                    return PriorityType.High;
                case "medium":
                    return PriorityType.Medium;
                case "low":
                    return PriorityType.Low;
                default:
                    throw new InvalidOperationException(InvalidPriorityType);
            }
        }

        public static BugSeverityType GetSeverityType(string severityType)
        {
            switch (severityType.ToLower())
            {
                case "critical":
                    return BugSeverityType.Critical;
                case "major":
                    return BugSeverityType.Major;
                case "minor":
                    return BugSeverityType.Minor;
                default:
                    throw new InvalidOperationException(InvalidSeverityType);
            }
        }

        public static BugStatusType GetStatusType(string statusType)
        {
            switch (statusType.ToLower())
            {
                case "active":
                    return BugStatusType.Active;
                case "fixed":
                    return BugStatusType.Fixed;
                default:
                    throw new InvalidOperationException(InvalidStatusType);
            }
        }
       
        public static StorySizeType GetSizeType(string sizeType)
        {
            switch (sizeType.ToLower())
            {
                case "large":
                    return StorySizeType.Large;
                case "medium":
                    return StorySizeType.Medium;
                case "small":
                    return StorySizeType.Small;
                default:
                    throw new InvalidOperationException(InvalidSizeType);
            }
        }

        public static StoryStatusType GetStoryStatusType(string storyStatusType)
        {
            switch (storyStatusType.ToLower())
            {
                case "done":
                    return StoryStatusType.Done;
                case "inprogress":
                    return StoryStatusType.InProgress;
                case "notdone":
                    return StoryStatusType.NotDone;
                default:
                    throw new InvalidOperationException(InvalidStatusType);
            }
        }

        public static FeedbackStatusType GetFeedbackStatusType(string feedbackStatusType)
        {
            switch (feedbackStatusType.ToLower())
            {
                case "done":
                    return FeedbackStatusType.Done;
                case "new":
                    return FeedbackStatusType.New;
                case "scheduled":
                    return FeedbackStatusType.Scheduled;
                case "unscheduled":
                    return FeedbackStatusType.Unscheduled;
                default:
                    throw new InvalidOperationException(InvalidStatusType);
            }
        }
        
    }
}
