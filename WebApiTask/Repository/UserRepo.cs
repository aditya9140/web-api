using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiTask.Context;
using WebApiTask.Interface;
using WebApiTask.Model.Dto;
using WebApiTask.Model.Entity;

namespace WebApiTask.Repository
{
    public class UserRepo : IUserRepo
    {
        private DataContext _dataContext;

        public UserRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<User> GetAllUserFromUrl()
        {
            string url = "https://jsonplaceholder.typicode.com/todos/";
            string json = new WebClient().DownloadString(url);
            List<User> userDetails = JsonConvert.DeserializeObject<List<User>>(json);
            return userDetails;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _dataContext.Users;
        }

        public bool StoreUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return true;
        }

        public bool UpdateUser(int id, UserDto userDto)
        {
            var user = _dataContext.Users.FirstOrDefault(s => s.Id == id);
            if (user != null)
            {
                _dataContext.Entry<User>(user).CurrentValues.SetValues(userDto);
                _dataContext.SaveChanges();
            }
            return true;
        }
    }
}
