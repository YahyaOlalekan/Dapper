namespace CodingPie.Models
{
    public interface IUserService
    {
         User Login(string email , string passWord);
    }
}