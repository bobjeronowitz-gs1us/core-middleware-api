using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace GS1US.Framework.API.Security
{
    public class GS1Principal
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly ClaimsIdentity _userIdentity;

        public GS1Principal(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
            _userIdentity = (ClaimsIdentity)claimsPrincipal.Identity;
        }

        private string GetClaimValue(string claimName)
        {
            var claim = _userIdentity.FindFirst(claimName);
            return claim?.Value ?? string.Empty;
        }

        private bool GetClaimValueBool(string claimName)
        {
            var result = false;
            var identityClaim = this.GetClaimValue(claimName);
            bool.TryParse(identityClaim, out result);
            return result;
        }

        private int GetClaimValueInt(string claimName)
        {
            var result = 0;
            var identityClaim = this.GetClaimValue(claimName);
            int.TryParse(identityClaim, out result);
            return result;
        }

        // Internal Claim Only for Use By Access Control
        private bool? _isGS1USAdmin;
        public bool IsGS1USAdmin
        {
            get
            {
                if (!this._isGS1USAdmin.HasValue)
                    this._isGS1USAdmin = GetClaimValueBool("IsGS1USAdmin");

                return this._isGS1USAdmin.Value;
            }
        }

        // Internal Claim Only for Use By Access Control
        private bool? _isGeneralUserAdmin;
        public bool IsGeneralUserAdmin
        {
            get
            {
                if (!this._isGeneralUserAdmin.HasValue)
                    this._isGeneralUserAdmin = GetClaimValueBool("IsGeneralUserAdmin");

                return this._isGeneralUserAdmin.Value;
            }
        }

        public string Email => this.GetClaimValue(ClaimTypes.Email);
        public int SelectedCompanyId => this.GetClaimValueInt("CompanyId");
        public int SelectedCompanyName => this.GetClaimValueInt("CompanyName");
        public string SelectedCompanyAccountNumber => this.GetClaimValue("CompanyAccountNo");

        private IList<UserClaim> _applicaionClaims = null;
        private IList<UserClaim> GetApplicationClaims()
        {
            if (_applicaionClaims == null)
            {
                var claimJson = this.GetClaimValue("applicationClaims");

                if (string.IsNullOrEmpty(claimJson))
                    _applicaionClaims = new List<UserClaim>();
                else
                    _applicaionClaims = JsonSerializer.Deserialize<IList<UserClaim>>(claimJson);
            }

            return _applicaionClaims;
        }

        // If Claim is Not Found a default expired claim will be returned. 
        public UserClaim GetApplicationClaim(int claimId)
        {
            var claim = GetApplicationClaims()?.FirstOrDefault(q => q.ClaimTypeId == claimId);
            return claim != null ? claim : UserClaim.DefaultClaim;
        }

        // If Claim is Not Found a default expired claim will be returned. 
        public UserClaim GetApplicationClaim(string claimName)
        {
            var claim = GetApplicationClaims()?.FirstOrDefault(q => q.ClaimName == claimName);
            return claim != null ? claim : UserClaim.DefaultClaim;
        }

        // If Claim is Not Found a default expired claim will be returned. 
        public UserClaim FindClaimByRange(IList<int> claimNames)
        {
            if (claimNames == null)
                throw new ArgumentNullException();

            UserClaim findClaim = UserClaim.DefaultClaim;
            foreach (var item in claimNames)
            {
                var itemClaim = GetApplicationClaim(item);
                if (itemClaim != null)
                {
                    findClaim = itemClaim;
                    break;
                }
            }

            return findClaim;
        }

        // If Claim is Not Found a default expired claim will be returned. 
        public UserClaim FindClaimByRange(IList<string> claimNames)
        {
            if (claimNames == null)
                throw new ArgumentNullException();

            UserClaim findClaim = UserClaim.DefaultClaim;
            foreach (var item in claimNames)
            {
                var itemClaim = GetApplicationClaim(item);
                if (!itemClaim.IsDefaultClaim)
                {
                    findClaim = itemClaim;
                    break;
                }
            }

            return findClaim;
        }

    }
}
