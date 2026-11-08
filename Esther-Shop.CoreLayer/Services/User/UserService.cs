using CodeYad_Blog_CoreLayer.Utilities;
using Esther_Shop.CoreLayer.Dtos.Users;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Esther_Shop.CoreLayer.Services.User
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

       
        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var PasswordHash = registerDto.Password.EncodeToMd5();
            var IsUserExisted = _context.Users.Any(m=>m.UserEmail == registerDto.UserEmail);
            if (IsUserExisted)
            {
                return OperationResult.Error("شما قبلا ثبت نام کرده اید");
            }
            _context.Users.Add(new Shop.DataLayer.Entities.User(){
                Password = PasswordHash,
                 UserEmail = registerDto.UserEmail,
                     Role = UserRole.User,
                     FullName=registerDto.FullName,
                     IsDelete = false,
             });
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public UserDto Login(UserLoginDto loginDto)
        {
            var PasswordHash = loginDto.Password.EncodeToMd5();
            var user=_context.Users.FirstOrDefault(n=>n.UserEmail==loginDto.UserEmail && n.Password==PasswordHash);
            if (user == null)
            {
                return null;
            }
            var userDto = new UserDto()
            {
                Password = user.Password,
                UserEmail = user.UserEmail,
                RegisterDate = user.CreationDate,
                UserId = user.Id,
                Role = user.Role,
                FullName= user.FullName
            } ;
            return userDto;

        }

        public UserDto GetUserById(int id)
        {
           var user=_context.Users.FirstOrDefault(t=>t.Id==id);
            if (user == null)
                return null;
        return new UserDto(){

                FullName = user.FullName,
                Password = user.Password,
                UserEmail = user.UserEmail,
                UserId = user.Id,
                RegisterDate = user.CreationDate,
                Role = user.Role
            };
        }

        public OperationResult EditUser(EditUserDto Command)
        {
            var user = _context.Users.FirstOrDefault(i => i.Id == Command.UserId);
            if (user == null)
                return  OperationResult.NotFound();
            user.FullName = Command.FullName; user.Role=Command.Role;
            _context.SaveChanges();
           return OperationResult.Success();
        }

        public UserFilterDto GetUserByFilter(int take, int pageId)
        {
            var result=_context.Users;
            var skip = (pageId - 1) * take;
            var user = new UserFilterDto()
            {
                Users = result.Skip(skip).Take(take).Select(user=>new UserDto()
                {
                    FullName = user.FullName,
                    Password = user.Password,
                    UserEmail = user.UserEmail,
                    UserId = user.Id,
                    RegisterDate = user.CreationDate,
                    Role = user.Role
                }).ToList()
            };
            user.GeneratePaging(result,take,pageId);
            return user;
        }
    }
}
