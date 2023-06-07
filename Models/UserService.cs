namespace CodingPie.Models
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService()
        {
            _repo = new UserRepository();
        }

        public User Login(string email, string passWord)
        {
            return _repo.Login(email,passWord);
        }
    }
}