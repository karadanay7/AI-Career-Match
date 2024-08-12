using BE.Application.Common.Interfaces;
using System.Security.Claims;

namespace BE.WebApi.Services
{
    public class CurrentUserManager : ICurrentUserService
    {
       private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid UserId => GetUserId();
      

        private Guid GetUserId()
        {
            if (_contextAccessor.HttpContext == null)
            {
            
                Console.WriteLine("HttpContext null, UID claim alınamıyor.");
                throw new Exception("HttpContext erişilemez.");
            }

            var userIdClaim = _contextAccessor.HttpContext?.User?.FindFirst("uid");

            
            if (userIdClaim == null)
            {
                
                Console.WriteLine("UID claim'i bulunamadı.");
              
                throw new Exception("Kullanıcı ID'si bulunamadı (uid claim).");
            }

        
            if (!Guid.TryParse(userIdClaim.Value, out var userId))
            {
              
                throw new Exception("UID claim'i geçersiz bir GUID formatında.");
            }

            return userId;
        }
    }
}
