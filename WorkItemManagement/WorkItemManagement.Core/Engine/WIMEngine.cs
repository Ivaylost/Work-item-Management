using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Core.Engine.Contracts;
using WorkItemManagement.Core.Factories;
using WorkItemManagement.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.Core.Engine
{
    public class WIMEngine : IEngine
    {
        private readonly WIMFactory wimFactory;
        private readonly Commands commands;
        private readonly List<IMember> allMembers;
        private readonly List<ITeam> allTeams;

        public WIMEngine()
        {
            this.wimFactory = new WIMFactory();
            this.commands = new Commands();
            this.allMembers = new List<IMember>();
            this.allTeams = new List<ITeam>();
        }

        public void Run()
        {
            commands.PrintMenu();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Please enter a command to continue (number between 1 and 34): ");

                string command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("Command can not be null or empty string");
                    continue;
                }

                if (command == "End")
                {
                    Console.WriteLine("End");
                    break;
                }
                try
                {
                    var output = this.ProcessCommand(command);
                    Console.WriteLine(output);
                    Console.WriteLine("=============================================================");
                }

                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                    var output = this.ProcessCommand(command);

                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    var output = this.ProcessCommand(command);

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    var output = this.ProcessCommand(command);
                }

                
            }
        }

        private string ProcessCommand(string command)
        {
            switch (command)
            {

                case "1":
                    Console.WriteLine("Enter a name for a new member:");
                    var memberToCreate = Console.ReadLine();
                    return this.CreateMember(memberToCreate);
                case "2":
                    Console.WriteLine("Enter a member's name:");
                    var memberNameToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a team's name:");
                    var teamNameToBeAdded = Console.ReadLine();
                    return this.AddMemberToTeam(memberNameToAdd, teamNameToBeAdded);
                case "3":
                    return this.ShowAllMembers();
                case "4":
                    Console.WriteLine("Enter a member's name to show his activity history:");
                    var memberToShowHistory = Console.ReadLine();
                    return this.ShowMemberActivity(memberToShowHistory);
                case "5":
                    Console.WriteLine("Enter a board's name:");
                    var boardName = Console.ReadLine();
                    Console.WriteLine("Enter a team where to add the board:");
                    var teamForAddingBoardTo = Console.ReadLine();
                    return this.CreateBoardInATeam(boardName, teamForAddingBoardTo);
                case "6":
                    Console.WriteLine("Enter a team's name to show boards:");
                    var teamToShowBoards = Console.ReadLine();
                    return this.ShowAllTeamBoards(teamToShowBoards);
                case "7":
                    Console.WriteLine("Enter a teams's name:");
                    var teamToCreate = Console.ReadLine();
                    return this.CreateTeam(teamToCreate);
                case "8":
                    return this.ShowAllTeams();
                case "9":
                    Console.WriteLine("Enter a team's name to show members:");
                    var teamToShowMembers = Console.ReadLine();
                    return this.ShowAllTeamMembers(teamToShowMembers);
                case "10":
                    Console.WriteLine("Enter a team to add bug:");
                    var bugTeamToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a board to add bug:");
                    var bugBoardToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a bug's title:");
                    var bugTitle = Console.ReadLine();
                    Console.WriteLine("Enter a bug's description:");
                    var bugDescription = Console.ReadLine();
                    Console.WriteLine("Enter a bug's priority:");
                    var bugPriority = Console.ReadLine();
                    Console.WriteLine("Enter a bug's severity:");
                    var bugSeverity = Console.ReadLine();
                    Console.WriteLine("Enter a bug's status:");
                    var bugStatus = Console.ReadLine();
                    Console.WriteLine("Enter a bug's asignee:");
                    var bugAsignee = Console.ReadLine();
                    Console.WriteLine("Enter a bug's steps to reproduce:");
                    var listStepsToReproduce = Console.ReadLine().Split().ToList();  // TODO CHECK THISS
                    return this.CreateBugInABoard(bugTeamToAdd, bugBoardToAdd, bugTitle, bugDescription,
                                                   listStepsToReproduce, bugPriority, bugSeverity,
                                                   bugStatus, bugAsignee);
                case "11":
                    Console.WriteLine("Enter a team to add story:");
                    var storyTeamToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a board to add story:");
                    var storyBoardToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a story's title:");
                    var storyTitle = Console.ReadLine();
                    Console.WriteLine("Enter a story's description:");
                    var storyDescription = Console.ReadLine();
                    Console.WriteLine("Enter a story's priority:");
                    var storyPriority = Console.ReadLine();
                    Console.WriteLine("Enter a story's size:");
                    var storySize = Console.ReadLine();
                    Console.WriteLine("Enter a story's status:");
                    var storyStatus = Console.ReadLine();
                    Console.WriteLine("Enter a story's asignee:");
                    var storyAsignee = Console.ReadLine();
                    return this.CreateStoryInABoard(storyTeamToAdd, storyBoardToAdd, storyTitle, storyDescription,
                                                   storyPriority, storySize, storyStatus, storyAsignee);
                case "12":
                    Console.WriteLine("Enter a team to add feedback:");
                    var feedbackTeamToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a board to add feedback:");
                    var feedbackBoardToAdd = Console.ReadLine();
                    Console.WriteLine("Enter a feedback's title:");
                    var feedbackTitle = Console.ReadLine();
                    Console.WriteLine("Enter a feedback's description:");
                    var feedbackDescription = Console.ReadLine();
                    Console.WriteLine("Enter a feedback's rating:");
                    int feedbackRating = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a feedback status:");
                    var statusType = Console.ReadLine();
                    return this.CreateFeedbackInABoard(feedbackTeamToAdd, feedbackBoardToAdd, feedbackTitle, feedbackDescription,
                                                   feedbackRating, statusType);
                case "13":
                    Console.WriteLine("Enter a team's name to change bug priority: ");
                    var teamToChangeBugPriority = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change bug priority: ");
                    var boardToChangeBugPriority = Console.ReadLine();
                    Console.WriteLine("Enter a bug's title: ");
                    var bugToChangePriority = Console.ReadLine();
                    Console.WriteLine("Enter a new bug's priority: ");
                    var bugNewPriority = Console.ReadLine();
                    return this.ChangeBugPriority(teamToChangeBugPriority, boardToChangeBugPriority,
                                                    bugToChangePriority, bugNewPriority);
                case "14":
                    Console.WriteLine("Enter a team's name to change bug status: ");
                    var teamToChangeBugStatus = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change bug status: ");
                    var boardToChangeBugStatus = Console.ReadLine();
                    Console.WriteLine("Enter a bug's title: ");
                    var bugToChangeStatus = Console.ReadLine();
                    Console.WriteLine("Enter a new bug's status: ");
                    var bugNewStatus = Console.ReadLine();
                    return this.ChangeBugStatus(teamToChangeBugStatus, boardToChangeBugStatus,
                                                    bugToChangeStatus, bugNewStatus);
                case "15":
                    Console.WriteLine("Enter a team's name to change bug severity: ");
                    var teamToChangeBugSeverity = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change bug severity: ");
                    var boardToChangeBugSeverity = Console.ReadLine();
                    Console.WriteLine("Enter a bug's title: ");
                    var bugToChangeSeverity = Console.ReadLine();
                    Console.WriteLine("Enter a new bug's severity: ");
                    var bugNewSeverity = Console.ReadLine();
                    return this.ChangeBugSeverity(teamToChangeBugSeverity, boardToChangeBugSeverity,
                                                    bugToChangeSeverity, bugNewSeverity);
                case "16":
                    Console.WriteLine("Enter a team's name to change story priority: ");
                    var teamToChangeStoryPriority = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change story priority: ");
                    var boardToChangeStoryPriority = Console.ReadLine();
                    Console.WriteLine("Enter a story's title: ");
                    var storyToChangePriority = Console.ReadLine();
                    Console.WriteLine("Enter a new story's priority: ");
                    var storyNewPriority = Console.ReadLine();
                    return this.ChangeStoryPriority(teamToChangeStoryPriority, boardToChangeStoryPriority,
                                                    storyToChangePriority, storyNewPriority);
                case "17":
                    Console.WriteLine("Enter a team's name to change story size: ");
                    var teamToChangeStorySize = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change story size: ");
                    var boardToChangeStorySize = Console.ReadLine();
                    Console.WriteLine("Enter a story's title: ");
                    var storyToChangeSize = Console.ReadLine();
                    Console.WriteLine("Enter a new story's size: ");
                    var storyNewSize = Console.ReadLine();
                    return this.ChangeStorySize(teamToChangeStorySize, boardToChangeStorySize,
                                                    storyToChangeSize, storyNewSize);
                case "18":
                    Console.WriteLine("Enter a team's name to change story status: ");
                    var teamToChangeStoryStatus = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change story status: ");
                    var boardToChangeStoryStatus = Console.ReadLine();
                    Console.WriteLine("Enter a story's title: ");
                    var storyToChangeStatus = Console.ReadLine();
                    Console.WriteLine("Enter a new story's status: ");
                    var storyNewStatus = Console.ReadLine();
                    return this.ChangeStoryStatus(teamToChangeStoryStatus, boardToChangeStoryStatus,
                                                    storyToChangeStatus, storyNewStatus);
                case "19":
                    Console.WriteLine("Enter a team's name to change a feedback status: ");
                    var teamToChangeFeedbackStatus = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change a feedback status: ");
                    var boardToChangeFeedbackStatus = Console.ReadLine();
                    Console.WriteLine("Enter a feedback's title: ");
                    var feedbackToChangeStatus = Console.ReadLine();
                    Console.WriteLine("Enter a new feedback's status: ");
                    var feedbackNewStatus = Console.ReadLine();
                    return this.ChangeFeedbackStatus(teamToChangeFeedbackStatus, boardToChangeFeedbackStatus,
                                                    feedbackToChangeStatus, feedbackNewStatus);
                case "20":
                    Console.WriteLine("Enter a team's name to change a feedback rating: ");
                    var teamToChangeFeedbackRating = Console.ReadLine();
                    Console.WriteLine("Enter a board's name to change a feedback rating: ");
                    var boardToChangeFeedbackRating = Console.ReadLine();
                    Console.WriteLine("Enter a feedback's title: ");
                    var feedbackToChangeRating = Console.ReadLine();
                    Console.WriteLine("Enter a new feedback's rating: ");
                    int rating = RatingAsInt();
                    return this.ChangeFeedbackRating(teamToChangeFeedbackRating, boardToChangeFeedbackRating,
                                                    feedbackToChangeRating, rating);
                case "21":
                    Console.WriteLine("Enter a team's name where to assign work item: ");
                    var teamToAssignWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a board's name where to assign work item: ");
                    var boardToAssignWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a work item's title: ");
                    var workItemToAssign = Console.ReadLine();
                    Console.WriteLine("Enter the member's name: ");
                    var memberToAssign = Console.ReadLine();
                    return this.AssignWorkItemToAMember(teamToAssignWorkItem, boardToAssignWorkItem,
                                                    workItemToAssign, memberToAssign);
                case "22":
                    Console.WriteLine("Enter a team's name where to assign work item: ");
                    var teamToUnAssignWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a board's name where to assign work item: ");
                    var boardToUnAssignWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a work item's title: ");
                    var workItemToUnAssign = Console.ReadLine();
                    Console.WriteLine("Enter the member's name: ");
                    var memberToUnAssign = Console.ReadLine();
                    return this.UnAssignWorkItemToAMember(teamToUnAssignWorkItem, boardToUnAssignWorkItem,
                                                    workItemToUnAssign, memberToUnAssign);
                case "23":
                    Console.WriteLine("Enter a team's name where to add a comment to a work item: ");
                    var teamToAddCommentToAWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a board's name where to add a comment to a work item: ");
                    var boardToToAddCommentToAWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a members's name to add a comment to a work item: ");
                    var memberToToAddCommentToAWorkItem = Console.ReadLine();
                    Console.WriteLine("Enter a work item's title to add a comment to: ");
                    var workItemToToAddCommentTo = Console.ReadLine();
                    Console.WriteLine("Enter a comment's description: ");
                    var commentDescriptionToAdd = Console.ReadLine();
                    return this.AddCommentToAWorkItem(teamToAddCommentToAWorkItem, boardToToAddCommentToAWorkItem,
                                                      memberToToAddCommentToAWorkItem, workItemToToAddCommentTo,
                                                      commentDescriptionToAdd);
                case "24":
                    return this.ListAllWorkItems();
                case "25":
                    Console.WriteLine("Enter a work item's type /Bug/Story/Feedback: ");
                    var workItemType = Console.ReadLine();
                    return this.FilterWorkItemsByType(workItemType);
                case "26":
                    Console.WriteLine("Enter a work item's status: ");
                    var workItemStatus = Console.ReadLine();
                    return this.FilterWorkItemsByStatus(workItemStatus);
                case "27":
                    Console.WriteLine("Enter a work item's status: ");
                    var workItemStatusToFilter = Console.ReadLine();
                    Console.WriteLine("Enter a member's name to filter: ");
                    var memeberNameToFilter = Console.ReadLine();
                    return this.FilterWorkItemsByStatusAndAssignee(workItemStatusToFilter, memeberNameToFilter);
                case "28":
                    Console.WriteLine("Enter a member's name to filter: ");
                    var memeberNameToFilterWorkItems = Console.ReadLine();
                    return this.FilterWorkItemsByAssigniee(memeberNameToFilterWorkItems);
                case "29":
                    Console.WriteLine("Enter a team's name to show board activity history:");
                    var teamToShowBoardActivity = Console.ReadLine();
                    Console.WriteLine("Enter a boards's name to show his activity history:");
                    var boardToShowActivity = Console.ReadLine();
                    return this.ShowBoardActivity(teamToShowBoardActivity, boardToShowActivity);
                case "30":
                    return this.SortWorkItemsByTitle();
                case "31":
                    return this.SortWorkItemsByPriority();
                case "32":
                    return this.SortWorkItemsBySeverity();
                case "33":
                    return this.SortWorkItemsBySize();
                case "34":
                    return this.SortWorkItemsByRating();

                default:
                    return string.Format(Constants.InvalidCommand, command);
            }
        }

        public string CreateBugInABoard(string teamName, string boardName, string bugTitle,
                                            string bugDescription, List<string> stepsToReproduce,
                                            string priorityType, string severityType, string statusType,
                                            string memberName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }
            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            if (!team.ListOfMembers.Any(m => m.Name == memberName))
            {
                return string.Format(Constants.MemberDoesNotExistInTeam, memberName, teamName);
            }
            if (board.ListOfWorkItems.Where(x => x.GetType() == typeof(Bug)).Any(y => y.Title == bugTitle))
            {
                return string.Format(Constants.BugAlreadyExistInBoard, bugTitle, boardName);
            }

            var member = allMembers.Where(m => m.Name == memberName).FirstOrDefault();


            var bug = this.wimFactory.CreateBug(bugTitle, bugDescription, stepsToReproduce,
                                      EnumHelper.GetPriorityType(priorityType), EnumHelper.GetSeverityType(severityType),
                                      EnumHelper.GetStatusType(statusType), member);

            board.AddBoardWorkItem(bug);
            member.AssignMemberWorkItem(bug);
            
            string result = string.Format(Constants.BugCreated, bugTitle, bugDescription, boardName);

            var activity = this.wimFactory.CreateActivity(result, member);
            member.AddMemberActivity(activity);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string CreateFeedbackInABoard(string teamName, string boardName, string feedbackTitle,
                                            string feedbackDescription, int rating, string statusType)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }
            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            if (board.ListOfWorkItems.Where(x => x.GetType() == typeof(FeedBack)).Any(y => y.Title == feedbackTitle))
            {
                return string.Format(Constants.BugAlreadyExistInBoard, feedbackTitle, boardName);
            }

            var feedback = this.wimFactory.CreateFeedback(feedbackTitle, feedbackDescription, rating,
                                      EnumHelper.GetFeedbackStatusType(statusType));

            board.AddBoardWorkItem(feedback);

            string result = string.Format(Constants.FeedbackCreated, feedbackTitle, feedbackDescription, boardName);

            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string CreateStoryInABoard(string teamName, string boardName, string storyTitle,
                                           string storyDescription, string priorityType,
                                           string sizeType, string statusType, string memberName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            if (!team.ListOfMembers.Any(m => m.Name == memberName))
            {
                return string.Format(Constants.MemberDoesNotExistInTeam, memberName, teamName);
            }
            if (board.ListOfWorkItems.Where(x => x.GetType() == typeof(Story)).Any(y => y.Title == storyTitle))
            {
                return string.Format(Constants.StoryAlreadyExistInBoard, storyTitle, boardName);
            }

            var member = allMembers.Where(m => m.Name == memberName).FirstOrDefault();

            var story = this.wimFactory.CreateStory(storyTitle, storyDescription,
                                      EnumHelper.GetPriorityType(priorityType), EnumHelper.GetSizeType(sizeType),
                                      EnumHelper.GetStoryStatusType(statusType), member);

            board.AddBoardWorkItem(story);
            member.AssignMemberWorkItem(story);

            string result = string.Format(Constants.StoryCreated, storyTitle, storyDescription, boardName);

            var activity = this.wimFactory.CreateActivity(result, member);

            member.AddMemberActivity(activity);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeBugStatus(string teamName, string boardName,
                                          string bugTitle, string newStatus)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var bugItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(Bug)).FirstOrDefault(y => y.Title == bugTitle);

            IBug newBugItem = (IBug)bugItem;

            newBugItem.ChangeStatus(EnumHelper.GetStatusType(newStatus));

            string result = string.Format(Constants.StatusWasChanged, bugTitle, newStatus);

            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string AssignWorkItemToAMember(string teamName, string boardName,
                                         string workItemTitle, string memberName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();


            var workItem = board.ListOfWorkItems.Where(w => w is ITask &&
                                                            w.Title == workItemTitle).FirstOrDefault();

            ITask newWorkItem = (ITask)workItem;

            var member = allMembers.Where(m => m.Name == memberName).FirstOrDefault();

            var oldMember = newWorkItem.Assignee;

            member.AssignMemberWorkItem(newWorkItem);
            oldMember.UnAssignMemberWorkItem(newWorkItem);

            string result = string.Format(Constants.AssignWorkItemByMember, workItemTitle, memberName);

            var activity = this.wimFactory.CreateActivity(result, member);
            member.AddMemberActivity(activity);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string UnAssignWorkItemToAMember(string teamName, string boardName,
                                         string workItemTitle, string memberName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var workItem = board.ListOfWorkItems.Where(w => w is ITask &&
                                                            w.Title == workItemTitle).FirstOrDefault();

            ITask newWorkItem = (ITask)workItem;

            var member = allMembers.Where(m => m.Name == memberName).FirstOrDefault();

            var oldMember = newWorkItem.Assignee;

            member.UnAssignMemberWorkItem(newWorkItem);
            oldMember.AssignMemberWorkItem(newWorkItem);

            string result = string.Format(Constants.UnAssignWorkItemByMember, workItemTitle, memberName);

            var activity = this.wimFactory.CreateActivity(result, member);
            member.AddMemberActivity(activity);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeBugPriority(string teamName, string boardName,
                                          string bugTitle, string newPriority)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var bugItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(Bug)).FirstOrDefault(y => y.Title == bugTitle);

            IBug newBugItem = (IBug)bugItem;

            newBugItem.ChangePriority(EnumHelper.GetPriorityType(newPriority));

            string result = string.Format(Constants.PriorityWasChanged, bugTitle, newPriority);

            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeBugSeverity(string teamName, string boardName,
                                         string bugTitle, string newSeverity)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var bugItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(Bug)).FirstOrDefault(y => y.Title == bugTitle);

            IBug newBugItem = (IBug)bugItem;

            newBugItem.ChangeSeverity(EnumHelper.GetSeverityType(newSeverity));

            string result = string.Format(Constants.BugSeverityWasChanged, bugTitle, newSeverity);

            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeStoryPriority(string teamName, string boardName,
                                         string storyTitle, string newPriority)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var storyItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(Story)).FirstOrDefault(y => y.Title == storyTitle);

            IStory newStoryItem = (IStory)storyItem;

            newStoryItem.ChangePriority(EnumHelper.GetPriorityType(newPriority));

            string result = string.Format(Constants.PriorityWasChanged, storyTitle, newPriority);

            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string AddCommentToAWorkItem(string teamName, string boardName, string memberName,
                                        string workItemTitle, string commentDescription)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            if (!DoesMemberExist(memberName))
            {
                return string.Format(Constants.MemberDoesNotExist, memberName);
            }

            var member = allMembers.FirstOrDefault(m => m.Name == memberName);

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var workItem = board.ListOfWorkItems.Where(w => w is ITask &&
                                                            w.Title == workItemTitle).FirstOrDefault();
            IWorkItem newWorkItem = (IWorkItem)workItem;

            var comment = wimFactory.CreateComment(commentDescription, member);

            newWorkItem.AddComment(comment);

            string result = string.Format(Constants.CommentWasAddedToAWorkItem, commentDescription, workItemTitle);
            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeStorySize(string teamName, string boardName,
                                        string storyTitle, string newSize)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var storyItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(Story)).FirstOrDefault(y => y.Title == storyTitle);

            IStory newStoryItem = (IStory)storyItem;

            newStoryItem.ChangeSize(EnumHelper.GetSizeType(newSize));

            string result = string.Format(Constants.StorySizeWasChanged, storyTitle, newSize);
            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeStoryStatus(string teamName, string boardName,
                                        string storyTitle, string newStatus)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var storyItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(Story)).FirstOrDefault(y => y.Title == storyTitle);

            IStory newStoryItem = (IStory)storyItem;

            newStoryItem.ChangeStatus(EnumHelper.GetStoryStatusType(newStatus));
            string result = string.Format(Constants.StatusWasChanged, storyTitle, newStatus);
            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeFeedbackStatus(string teamName, string boardName,
                                        string feedbackTitle, string newStatus)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var feedbackItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(FeedBack)).FirstOrDefault(y => y.Title == feedbackTitle);

            IFeedback newFeedbackItem = (IFeedback)feedbackItem;

            newFeedbackItem.ChangeStatus(EnumHelper.GetFeedbackStatusType(newStatus));
            string result = string.Format(Constants.StatusWasChanged, feedbackTitle, newStatus);
            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ChangeFeedbackRating(string teamName, string boardName,
                                        string feedbackTitle, int newRating)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            var feedbackItem = board.ListOfWorkItems.Where(x => x.GetType() ==
                      typeof(FeedBack)).FirstOrDefault(y => y.Title == feedbackTitle);

            IFeedback newFeedbackItem = (IFeedback)feedbackItem;

            newFeedbackItem.ChangeRating(newRating);
            string result = string.Format(Constants.RatingWasChanged, feedbackTitle, newRating);
            var activity = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(activity);
            team.AddTeamActivity(activity);

            return result;
        }

        private string AddMemberToTeam(string memberName, string teamName)
        {
            if (!DoesMemberExist(memberName))
            {
                return string.Format(Constants.MemberDoesNotExistInTeam, memberName, teamName);
            }
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }
            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (team.ListOfMembers.Any(m => m.Name == memberName))
            {
                return string.Format(Constants.MemberAlreadyExistInTeam, memberName);
            }

            var member = allMembers.Where(m => m.Name == memberName).FirstOrDefault();

            team.AddMemberToTeam(member);

            string result = string.Format(Constants.MemberAddedToTeam, memberName, teamName);

            var history = this.wimFactory.CreateActivity(result, member);
            member.AddMemberActivity(history);
            team.AddTeamActivity(history);

            return result;
        }

        private string CreateMember(string name)
        {
            if (DoesMemberExist(name))
            {
                return string.Format(Constants.MemberAlreadyExist, name);
            }
            var member = this.wimFactory.CreateMember(name);
            allMembers.Add(member);

            string result = string.Format(Constants.MemberCreated, name);

            var activity = this.wimFactory.CreateActivity(result, member);
            member.AddMemberActivity(activity);

            return result;
        }

        private string ShowMemberActivity(string memberName)
        {
            if (!DoesMemberExist(memberName))
            {
                return string.Format(Constants.MemberDoesNotExist, memberName);
            }

            var member = allMembers.FirstOrDefault(m => m.Name == memberName);

            var result = member.ReturnMemberActivityToString();

            return result;
        }

        private string CreateTeam(string name)
        {
            if (DoesTeamExist(name))
            {
                return string.Format(Constants.TeamAlreadyExist, name);
            }
            var team = this.wimFactory.CreateTeam(name);
            this.allTeams.Add(team);

            string result = string.Format(Constants.TeamCreated, name);

            var activity = this.wimFactory.CreateActivity(result);
            team.AddTeamActivity(activity);

            return result;
        }

        private string ShowAllMembers()
        {
            if (this.allMembers.Count == 0)
            {

                return $"There are no members";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("All members: ");

            foreach (var member in allMembers)
            {
                sb.AppendLine($"\"{member.Name}\"");
            }

            return sb.ToString().TrimEnd();
        }

        private string ShowAllTeams()
        {
            if (this.allTeams.Count == 0)
            {
                return $"There are no teams";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("All teams: ");

            foreach (var team in allTeams)
            {
                sb.AppendLine($"\"{team.Name}\"");
            }

            return sb.ToString().TrimEnd();
        }

        private string ShowAllTeamMembers(string teamName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            if (this.allTeams.Count == 0)
            {
                return $"There are no teams";
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            var sb = new StringBuilder();
            sb.AppendLine("All members in the team: ");
            sb.AppendLine(team.ReturnListOfMembers());

            return  sb.ToString().TrimEnd();
        }

        private string CreateBoardInATeam(string boardName, string teamName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardAlreadyExistInTeam, boardName);
            }

            var board = this.wimFactory.CreateBoard(boardName);
            team.AddBoardInTeam(board);

            string result = string.Format(Constants.BoardAddedToTeam, boardName, teamName);

            var history = this.wimFactory.CreateActivity(result);
            board.AddBoardActivity(history);
            team.AddTeamActivity(history);

            return result;
        }

        private string ShowBoardActivity( string teamName, string boardName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            if (!team.ListOfBoards.Any(b => b.Name == boardName))
            {
                return string.Format(Constants.BoardDoesNotExistInTeam, boardName, teamName);
            }

            var board = team.ListOfBoards.Where(b => b.Name == boardName).FirstOrDefault();

            string result = board.ReturnBoardActivityToString();

            return result;
        }

        private string ShowAllTeamBoards(string teamName)
        {
            if (!DoesTeamExist(teamName))
            {
                return string.Format(Constants.TeamDoesNotExist, teamName);
            }

            var team = allTeams.Where(t => t.Name == teamName).FirstOrDefault();

            string result = team.ReturnListOfBoards();

            return "All boards in the team: \n" + result.Trim();
        }

        private string ListAllWorkItems()
        {
            var sb = new StringBuilder();

            foreach (var team in allTeams)
            {
                foreach (var board in team.ListOfBoards)
                {
                    sb.AppendLine(board.ReturnBoardWorkItemsToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        private string FilterWorkItemsByType(string workItemType)
        {
            var sb = new StringBuilder();

            foreach (var team in allTeams)
            {
                foreach (var board in team.ListOfBoards)
                {
                    sb.AppendLine(board.ReturnBoardWorkItemsToString(workItemType));
                }
            }

            return sb.ToString().TrimEnd();
        }

        private string FilterWorkItemsByStatus(string workItemStatus)
        {
            var sb = new StringBuilder();

            foreach (var team in allTeams)
            {
                foreach (var board in team.ListOfBoards)
                {
                    sb.AppendLine(board.ReturnBoardWorkItemsByStatusToString(workItemStatus));
                }
            }

            return sb.ToString().TrimEnd();
        }

        private string FilterWorkItemsByAssigniee(string memberName)
        {
            if (!DoesMemberExist(memberName))
            {
                return string.Format(Constants.MemberDoesNotExist, memberName);
            }

            var member = allMembers.FirstOrDefault(m => m.Name == memberName);

            string result = member.ReturnMemberWorkItemsToString();

            return result;
        }

        private string FilterWorkItemsByStatusAndAssignee(string workItemStatus, string memberName)
        {
            if (!DoesMemberExist(memberName))
            {
                return string.Format(Constants.MemberDoesNotExist, memberName);
            }

            var member = allMembers.FirstOrDefault(m => m.Name == memberName);

            string result = member.ReturnMemberWorkItemsByStatusToString(workItemStatus);

            return result;
        }

        private string SortWorkItemsByTitle()
        {
            var allWorkItems = new List<IWorkItem>();
            var sb = new StringBuilder();

            foreach (var team in allTeams)
            {
                foreach (var board in team.ListOfBoards)
                {
                    allWorkItems = allWorkItems.Concat(board.ListOfWorkItems).ToList();
                }
            }

            var sortedList = allWorkItems.OrderBy(w => w.Title).ToList();

            foreach (var item in sortedList)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString();
        }

        private string SortWorkItemsByPriority()
        {
            List<string> stringList = new List<string>();

            string str = string.Empty;

            foreach (var member in allMembers)
            {
                foreach (var workItem in member.ListOfMemberWorkItems)
                {
                    if (workItem is IBug)
                    {
                        IBug newWorkItem = (IBug)workItem;
                        str = $"Priority: \"{newWorkItem.PriorityType}\", Title: \"{newWorkItem.Title}\"";
                        stringList.Add(str);
                    }

                    if (workItem is IStory)
                    {
                        IStory newWorkItem = (IStory)workItem;
                        str = $"Priority: \"{newWorkItem.PriorityType}\", Title: \"{newWorkItem.Title}\"";
                        stringList.Add(str);
                    }
                }
            }

            stringList.Sort();
            var sb = new StringBuilder();

            foreach (var item in stringList)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }

        private string SortWorkItemsBySeverity()
        {
            // TODO: This needs refactoring
            List<string> stringList = new List<string>();

            string str = string.Empty;

            foreach (var member in allMembers)
            {
                foreach (var workItem in member.ListOfMemberWorkItems)
                {
                    if (workItem is IBug)
                    {
                        IBug newWorkItem = (IBug)workItem;
                        str = $"Severity: \"{newWorkItem.SeverityType}\", Title: \"{newWorkItem.Title}\"";
                        stringList.Add(str);
                    }
                }
            }

            stringList.Sort();
            var sb = new StringBuilder();

            foreach (var item in stringList)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }

        private string SortWorkItemsBySize()
        {
            List<string> stringList = new List<string>();

            string str = string.Empty;

            foreach (var member in allMembers)
            {
                foreach (var workItem in member.ListOfMemberWorkItems)
                {
                    if (workItem is IStory)
                    {
                        IStory newWorkItem = (IStory)workItem;
                        str = $"Size: \"{newWorkItem.SizeType}\", Title: " +
                            $"\"{newWorkItem.Title}\"";
                        stringList.Add(str);
                    }
                }
            }

            stringList.Sort();
            var sb = new StringBuilder();

            foreach (var item in stringList)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }

        private string SortWorkItemsByRating()
        {
            List<string> stringList = new List<string>();

            string str = string.Empty;

            foreach (var team in allTeams)
            {
                foreach (var board in team.ListOfBoards)
                {
                    foreach (var workItem in board.ListOfWorkItems)
                    {
                        if (workItem is IFeedback)
                        {
                            IFeedback newWorkItem = (IFeedback)workItem;
                            str = $"Rating: \"{newWorkItem.Rating}\", Title: " +
                                $"\"{newWorkItem.Title}\"";
                            stringList.Add(str);
                        }
                    }
                }
            }

            stringList.Sort();
            var sb = new StringBuilder();

            foreach (var item in stringList)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }

        private bool DoesMemberExist(string name)
        {
            bool contains = this.allMembers.Any(m => m.Name == name);

            if (contains)
            {
                return true;
            }

            return false;
        }

        private bool DoesTeamExist(string name)
        {
            bool contains = this.allTeams.Any(m => m.Name == name);

            if (contains)
            {
                return true;
            }

            return false;
        }

        private int RatingAsInt()
        {
            int rating;

            while (true)
            {
                string ratingAsString = Console.ReadLine();

                bool success = Int32.TryParse(ratingAsString, out rating);

                if (success)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer:");
                }
            }

            return rating;
        }
    }
}




