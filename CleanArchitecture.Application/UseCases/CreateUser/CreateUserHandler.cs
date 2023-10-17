using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;       
        private readonly IMapper _mapper;                       

        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            //Injeção de dependência
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            //Mapear as diferentes classes de entidade
            var user = _mapper.Map<User>(request);

            //Repositório (tabela) Usuário
            _userRepository.Create(user);

            //Controle da transação
            await _unitOfWork.Commit(cancellationToken);

            //Mapear as diferentes classes de entidade
            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
