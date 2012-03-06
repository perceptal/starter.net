
namespace Core.Web
{
    /// <summary>
    /// The different types of message boxes that can be displayed.
    /// </summary>
    public enum MessageClassifier
    {
        Information,
        Exclamation,
        Error
    }

    /// <summary>
    /// The Model for a message box
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// The text to display in the message box
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The type of message to be displayed in the message box
        /// </summary>
        public MessageClassifier Classifier { get; set; }
    }
}
