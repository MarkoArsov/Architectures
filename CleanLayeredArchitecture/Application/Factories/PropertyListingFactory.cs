using Application.Factories.Interfaces;
using Commmon.Result;
using Domain.Entities;

namespace Application.Factories
{
    public class PropertyListingFactory : IPropertyListingFactory
    {
        public Result<PropertyListing> Create(int? id, string title, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return Result<PropertyListing>.FailureResult("Title is required");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                return Result<PropertyListing>.FailureResult("Description is required");
            }

            if (price <= 0)
            {
                return Result<PropertyListing>.FailureResult("Price must be greater than 0");
            }

            PropertyListing listing = new PropertyListing
            {
                Id = id ?? 0,
                Title = title,
                Description = description,
                Price = price
            };

            return Result<PropertyListing>.SuccessResult(listing);

        }
    }

}
