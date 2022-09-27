using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface IJWT
    {
        string CreateToken(User user);
    }
}
