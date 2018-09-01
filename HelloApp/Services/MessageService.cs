namespace HelloApp.Services
{
    public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string Send()
        {
            return _sender.Send();
        }
    }
}
