using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Wrappers.Abstract
{
    public interface ISuccessResponse : IResponse
    {
        string Message { get; }
    }
}
