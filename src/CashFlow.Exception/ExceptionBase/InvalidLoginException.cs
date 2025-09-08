using CashFlow.Exception.ExpenseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Exception.ExceptionBase
{
    public class InvalidLoginException : CashFlowException
    {
        public override int StatusCode => (int)HttpStatusCode.Unauthorized;


        public InvalidLoginException() : base(ResourceErrorMessage.EMAIL_OR_PASSWORD_INVALID)
        {
        }
        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
