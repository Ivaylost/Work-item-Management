using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Contracts;
using WorkItemManagement.Models.Interfaces;

namespace WorkItemManagement.Models
{
    public class Team : ITeam
    {
        private string name;
        private ICollection<IMember> listOfMembers;
        private ICollection<IBoard> listOfBoards;
        private ICollection<IActivity> listOfActivity;

        public Team(string name)
        {
            this.Name = name;
            this.listOfMembers = new List<IMember>();
            this.listOfBoards = new List<IBoard>();
            this.listOfActivity = new List<IActivity>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The team's name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public ICollection<IMember> ListOfMembers
        {
            get
            {
                return new List<IMember>(listOfMembers);
            }
        }

        public ICollection<IBoard> ListOfBoards
        {
            get
            {
                return new List<IBoard>(listOfBoards);
            }
        }

        public ICollection<IActivity> ListOfActivity
        {
            get
            {
                return new List<IActivity>(listOfActivity);
            }
        }

        public void AddTeamActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentException("Cannot add empty activity history");
            }

            this.listOfActivity.Add(activity);
        }

        public void AddMemberToTeam(IMember member)
        {
            if (member==null)
            {
                throw new ArgumentException("Cannot add empty member");
            }
            this.listOfMembers.Add(member);
        }

        public void AddBoardInTeam(IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentException("Cannot add empty board");
            }
            this.listOfBoards.Add(board);
        }

        public string ReturnListOfMembers()
        {
            var sb = new StringBuilder();

            foreach (var member in listOfMembers)
            {
                sb.AppendLine($"\"{member.Name}\"");
            }
            return sb.ToString().TrimEnd();
        }

        public string ReturnListOfBoards()
        {
            var sb = new StringBuilder();

            foreach (var board in listOfBoards)
            {
                sb.AppendLine($"\"{board.Name}\"");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
