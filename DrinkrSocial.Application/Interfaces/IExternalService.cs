using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces
{
    public interface IExternalService<TInput, TOutput>
    {
        Task<TOutput> InvokeAsync(TInput inputToExternalService);
    }
}
