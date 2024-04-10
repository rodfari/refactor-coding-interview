using LegacyApp.Domain.Enums;

namespace LegacyApp.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ClientStatus ClientStatus { get; set; }


        
    }
}
