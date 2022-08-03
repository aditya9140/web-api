using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTask.Model.Dto;
using WebApiTask.Model.Entity;

namespace WebApiTask.Interface
{
    public interface IUserRepo
    {
        bool StoreUser(User user);
        List<User> GetAllUserFromUrl();
        IEnumerable<User> GetAllUser();
        bool UpdateUser(int id, UserDto user);
    }
}
