using MediatR;
using Shop.Data;
using Shop.Models;
using Shop.Repositories;
using Shop.Requests;
using Shop.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class UserRegisterService :
        IRequestHandler<ResgisterUserRequest, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _Uow;

        public UserRegisterService(IUserRepository userRepository, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _Uow = uow;
        }

        public Task<RegisterResponse> Handle(ResgisterUserRequest request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByEmail(request.Email);
            if (user != null)
                return Task.FromResult( 
                    new RegisterResponse() 
                    {
                        DeuCerto = false,
                        
                    });

            var newUser = new Usuario()
            {
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                Username = request.Username,
            };

            _userRepository.SaveUser(newUser);
            var response = new RegisterResponse()
            {
                DeuCerto = true,
                Data = DateTime.Now
            };
            _Uow.Commit();
            return Task.FromResult(response);
        }

        public Task<Usuario> Register(ResgisterUserRequest resgisterUserRequest)
        {
            var user = _userRepository.GetUserByEmail(resgisterUserRequest.Email);
            if (user != null)
            {
                throw new Exception("Usuário Já cadastrado!");
            }

            var newUser = new Usuario()
            {
                Email = resgisterUserRequest.Email,
                Password = resgisterUserRequest.Password,
                Role = resgisterUserRequest.Role,
                Username = resgisterUserRequest.Username,
            };

            _userRepository.SaveUser(newUser);
            _Uow.Commit();
            return Task.FromResult(newUser);
        }


    }
}
