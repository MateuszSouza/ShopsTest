using MediatR;
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
    public class LoginService
        : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var ususarioFromRepository =
                _userRepository.GetUserByUserNameAndPassword(request.Username, request.Password);
            if (ususarioFromRepository == null)
                //throw new Exception("usuário ou senha inválidos");
                return Task.FromResult( new LoginResponse { Token = "" });

            var token = GeradorDeTokenSevice.TokenGenerator(ususarioFromRepository);
            ususarioFromRepository.Password = "";
            var response = new LoginResponse()
            {
                Token = token,
                Usuario = ususarioFromRepository
            };
            return Task.FromResult( response);
        }
    }
}
