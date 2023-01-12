namespace Api.Model
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }

        public string messageTitle { get; set; }

        public bool isActive { get; set; }

        public DateTime registrationDate { get; set; }

        public DateTime changeDate { get; set; }
        public string userId { get; set; }
  

    }
}
