using GraphQLSample.GraphQL.Mutation;
using GraphQLSample.Models;
using System.Diagnostics;

namespace GraphQLSample.GraphQL.Subscription
{
    public class Subscription
    {
        [Subscribe]
        [Topic(nameof(ProductMutations.AddProductAsync))]
        public Product ProductAdded([EventMessage] Product product)
        {
            Debug.WriteLine("Event consumed");
            return product;
        }
    }
}
