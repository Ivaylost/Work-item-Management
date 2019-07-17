using System;
using WorkItemManagement.Core.Engine.Contracts;

namespace WorkItemManagement.Core.Engine
{
    public  class Commands : ICommands
    {

        public  void PrintMenu()
        {
            Console.WriteLine(" 1. CreateMember                2. AddMemberToTeam,          3. ShowAllMembers               4. ShowMemberActivity");
            Console.WriteLine(" 5. CreateNewBoardInATeam       6. ShowAllTeamBoards         7. CreateTeam                   8. ShowAllTeams");
            Console.WriteLine(" 9. ShowAllTeamMembers         10. CreateBugInABoard        11. CreateStoryInABoard         12. CreateFeedbackInABoard");
            Console.WriteLine("13. ChangePriorityOfBug        14. ChangeStatusOfBug        15. ChangeSeverityOfBug         16. ChangePriorityOfStory");
            Console.WriteLine("17. ChangeSizeOfStory          18. ChangeStatusOfStory      19. ChangeStatusOfFeedback      20. ChangeRatingOfFeedback");
            Console.WriteLine("21. AssignWorkItem             22. UnAssignWorkItem         23. AddCommentToWorkItem        24. ListWorkItems");
            Console.WriteLine("25. FilterWorkItemsByType      26. FilterWorkItemsByStatus  27. FilterWIByStatusAndMember");
            Console.WriteLine("28. FilterWorkItemsByAssignee  29. ShowBoardActivity        30. SortWorkItemsByTitle");
            Console.WriteLine("31. SortWorkItemsByPriority    32. SortWorkItemsBySeverity  33. SortWorkItemsBySize         34. SortWorkItemsByRating");
        }
    }
}
