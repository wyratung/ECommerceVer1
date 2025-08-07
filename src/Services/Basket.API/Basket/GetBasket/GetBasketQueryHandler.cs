using Basket.API.Data;
using Basket.API.Models;
using Common.CQRS;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);

    public class GetBasketQueryHandler(IBasketRepository repository)
        : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var x = new Int128();
            x.Equals(0);
            var basket = await repository.GetBasket(query.UserName);

            return new GetBasketResult(basket);
        }
    }
}
