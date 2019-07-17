using WorkItemManagement.Enums;

namespace WorkItemManagement.Contracts
{
    public interface IStory : IWorkItem, ITask
    {
        StorySizeType SizeType { get; }

        StoryStatusType StatusType { get; }

        void ChangeSize(StorySizeType storySizeType);

        void ChangeStatus(StoryStatusType storyStatusType);
    }
}
