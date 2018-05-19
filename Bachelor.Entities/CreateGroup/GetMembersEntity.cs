using System;

namespace Bachelor.Entities.CreateGroup
{
    public class GetMembersEntity
    {
        public Guid ProviderGuid { get; set; }

        public string FirstName { get; set; }

        public bool IsAdmin { get; set; }

    }
}
