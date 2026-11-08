using Esther_Shop.CoreLayer.Dtos.Users;
using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.User
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);
        UserDto Login(UserLoginDto loginDto);
        UserDto GetUserById(int id);
        OperationResult EditUser(EditUserDto Command);
        UserFilterDto GetUserByFilter(int take,int pageId);

    }
}
