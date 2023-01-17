using Application.Interfaces;
using Domain.Interfaces;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task createUser(User user)
        {
            if(user != null)
            {
                await _userRepository.CreateUser(user);
                return;
            }

            throw new Exception("Не удалось создать пользователя");
        }

        public async Task<User> getUserById(int id)
        {
            var result = await _userRepository.getUserById(id);

            if (result != null)
                return result;

            throw new Exception("Не удалось найти пользователя");
        }
    }
}
