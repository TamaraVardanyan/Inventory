using Inventory.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(UserDTO userDto);
        Task<string?> LoginAsync(LoginDTO loginDto);
    }
}
