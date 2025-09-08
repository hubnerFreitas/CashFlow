using CashFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Sercurity.Tokens
{
    public interface IAccessTokenGenerator
    {
        string GenerateToken(Users user);
    }
}
