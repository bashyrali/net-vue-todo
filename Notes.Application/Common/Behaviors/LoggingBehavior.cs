﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Notes.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            throw new System.NotImplementedException();
        }
    }
}