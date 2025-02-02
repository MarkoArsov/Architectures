using Commmon.Result;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
public class PropertyListingRepository : IPropertyListingRepository
{
    private readonly ApplicationDbContext _context;

    public PropertyListingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<IEnumerable<PropertyListing>>> GetAllAsync()
    {
        var listings = await _context.PropertyListings.ToListAsync();

        if (listings.Count == 0)
        {
            return Result<IEnumerable<PropertyListing>>.FailureResult("No property listings found.");
        }

        return Result<IEnumerable<PropertyListing>>.SuccessResult(listings);
    }

    public async Task<Result<PropertyListing>> GetByIdAsync(int id)
    {
        var listing = await _context.PropertyListings.FindAsync(id);

        if (listing == null)
        {
            return Result<PropertyListing>.FailureResult($"Property listing with id {id} not found.");
        }

        return Result<PropertyListing>.SuccessResult(listing);
    }

    public void Add(PropertyListing property)
    {
        _context.PropertyListings.Add(property);
    }

    public void Update(PropertyListing property)
    {
        _context.PropertyListings.Update(property);
    }

    public void Delete(PropertyListing property)
    {
        _context.PropertyListings.Remove(property);
    }
}


}
