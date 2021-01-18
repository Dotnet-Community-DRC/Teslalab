using System;

namespace Teslalab.Shared
{
    public class LoginResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}