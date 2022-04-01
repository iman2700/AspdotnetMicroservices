using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery,List<OrdersVm>>
    {
        private readonly IOrderRepository _ordereRepository;
        private readonly IMapper mapper;

        public GetOrderListQueryHandler(IOrderRepository ordereRepository, IMapper mapper)
        {
            _ordereRepository = ordereRepository;
            this.mapper = mapper;
        }

        public async Task<List<OrdersVm>> Handle(GetOrderListQuery request, CancellationToken cancellationToken) 
        {
            var orderList = await _ordereRepository.GetOrdersByUserName(request.UserName);
            return mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}
