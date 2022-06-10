using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using DrinkrSocial.Domain.Entities.Models.Taverns;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Taverns.Commands
{
    public class GetNearbyTavernsCommand : IRequest<IResponse>
    {
        public string PostalCode { get; set; }


        public class GetNearbyTavernsCommandHandler : IRequestHandler<GetNearbyTavernsCommand, IResponse>
        {
            private readonly ITavernRepository _tavernRepository;

            public GetNearbyTavernsCommandHandler(ITavernRepository tavernRepository)
            {
                _tavernRepository = tavernRepository;
            }
            
            public async Task<IResponse> Handle(GetNearbyTavernsCommand request, CancellationToken cancellationToken)
            {
                var tavernsNearby = await _tavernRepository.GetAllAsync(x => x.PostalCode == request.PostalCode);

                if (tavernsNearby == null)
                    throw new ApiException(400, ResponseMessages.NoTavernsNearby);

                return new PagedDataResponse<IEnumerable<Tavern>>(tavernsNearby, 200, tavernsNearby.Count());
            }
        }
    }
}
