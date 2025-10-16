namespace Project.Data.Dtos
{
    public class CreateConversationRequest
    {
        public string ClientId { get; set; } = null!;
        public string ServiceOwnerId { get; set; } = null!;
    }

}
