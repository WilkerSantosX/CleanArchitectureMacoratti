using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public class GetAllUserValidator : AbstractValidator<GetAllUserResponse>
    {
        public GetAllUserValidator()
        {
           //Sem validação por se tratar de uma consulta     
        }
    }
}
