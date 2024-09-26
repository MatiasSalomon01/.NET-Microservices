using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQuery<out TRespose> : IRequest<TRespose> where TRespose : notnull { }