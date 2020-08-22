namespace NSE.Identity.API.Dtos
{
    public class UserClaimDto
    {
        public string Type { get; }
        public string Value { get; }

        public UserClaimDto(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}