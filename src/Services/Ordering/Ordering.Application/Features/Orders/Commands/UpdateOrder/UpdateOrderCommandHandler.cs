using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exception;
using Ordering.Domain.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
           //update order
           var OrderToUpdate=await _orderRepository.GetByIdAsync(request.Id);
            if(OrderToUpdate== null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            _mapper.Map(request, OrderToUpdate,typeof(UpdateOrderCommand),typeof(Order));
            await _orderRepository.UpdateAsync(OrderToUpdate);
            _logger.LogInformation($"Order {OrderToUpdate.Id} is successfuly update");
            return Unit.Value;

        }
    }
}
