using DrinkrSocial.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Wrappers.Abstract
{
    interface IPagedDataResponse<T> : IResponse
    {
        int TotalItems { get; }
        T Data { get; }
    }
}
