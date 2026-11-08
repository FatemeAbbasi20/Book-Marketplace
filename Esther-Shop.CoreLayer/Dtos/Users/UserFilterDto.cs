using Esther_Shop.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Dtos.Users
{
    public class UserFilterDto:BasePagination
    {
        public List<UserDto> Users { get; set; } = new();
    }
}
