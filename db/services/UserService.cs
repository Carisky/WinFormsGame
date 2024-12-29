using System.Threading.Tasks;
using WinFormsGame.db.models;
using WinFormsGame.db.repositories;

namespace WinFormsGame.db.services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Find User by Name
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            // Get the user by username
            var user = await _userRepository.GetUserByUsernameAsync(username);

            // Check if the user exists and the password matches
            if (user != null)
            {
                return user; // Authentication successful
            }

            return null; // Authentication failed
        }

        // Authenticate User
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            // Get the user by username
            var user = await _userRepository.GetUserByUsernameAsync(username);

            // Check if the user exists and the password matches
            if (user != null && user.Password == password)
            {
                return user; // Authentication successful
            }

            return null; // Authentication failed
        }

        // Add or Update User
        public async Task AddOrUpdateUserAsync(User user)
        {
            await _userRepository.AddOrUpdateUserAsync(user);
        }

        // Get all Users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Get User by Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // Delete User by Id
        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        // Update User's Highscore
        public async Task UpdateHighscoreAsync(int userId, int newHighscore)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user != null && user.Highscore < newHighscore)
            {
                user.Highscore = newHighscore;
                await _userRepository.AddOrUpdateUserAsync(user);
            }
        }
    }
}
