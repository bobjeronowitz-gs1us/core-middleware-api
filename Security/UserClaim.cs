using System;

namespace GS1US.Framework.API.Security
{
    public class UserClaim
    {
        public const short DEFAULT_MISSING_CLAIM = -99;

        public int ClaimTypeId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimDescription { get; set; }
        public bool IsSystem { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool NotExpired()
        {
            return ExpirationDate > DateTime.UtcNow;
        }

        // Return Empty Default Claim that is expired
        public static UserClaim DefaultClaim => new UserClaim { ClaimTypeId = DEFAULT_MISSING_CLAIM, ExpirationDate = DateTime.MinValue };

        public bool IsDefaultClaim => ClaimTypeId == DEFAULT_MISSING_CLAIM;
    }
}
