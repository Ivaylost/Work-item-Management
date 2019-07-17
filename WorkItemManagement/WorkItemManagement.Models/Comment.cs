using System;
using WorkItemManagement.Contracts;
using WorkItemManagement.Models.Interfaces;

namespace WorkItemManagement.Models
{
    public class Comment : IComment
    {
        private string message;

        public Comment(string message, IMember author)
        {
            this.Message = message;
            this.Author = author;
        }

        public IMember Author { get;  }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Message cannot be null or empty string.");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Message should be at least 3 symbols.");
                }

                this.message = value;
            }
        }
    }
}
