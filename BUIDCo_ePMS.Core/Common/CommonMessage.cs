using System.ComponentModel;

namespace BUIDCo_ePMS.Core
{
    /// <summary>
    /// Summary description for CommonMessage
    /// </summary>
    public class Message
    {
        public int MessageNumber { get; set; }
        public string MessageDescription { get; set; }
    }
    public static class MessageHandler
    {
        // Dictionary for fast lookup
        private static Dictionary<int, string> messages = new Dictionary<int, string>
        {
            //user confirm message section
            { 1, "Record Saved Successfully!" },
            { 2, "Record Updated Successfully!" },
            { 3, "Record Deleted Successfully!" },
            { 4, "Record Already Exists!" },
             { 5, "Letter Generated Successfully!" },
             { 6, "Action Taken Successfully!" },

            //user validation message section
            { 10, "Please enter valid" },
            { 11, "Special characters like @@, $, &, ; are not allowed" },
        };
        public static string GetMessageDescription(int messageNumber)
        {
            return messages.TryGetValue(messageNumber, out var description)
                ? description
                : "Unknown Message Number";
        }
    }
}
