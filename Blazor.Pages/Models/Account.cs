

namespace Blazor.Pages.Models
{
    public class Account
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public bool KeepMyEmailAddressPrivate { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public bool AutomaticallyWatchRepositories { get; set; }
        public bool ReceiveUpdateToAnyConversationsViaMail { get; set; }
        public bool ReceiveUpdateToAnyRepositoriesViaEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewPassord { get; set; }
        public string ConfirPassword { get; set; }
    }
}
