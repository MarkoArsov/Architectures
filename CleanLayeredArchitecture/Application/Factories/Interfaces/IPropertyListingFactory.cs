using Commmon.Result;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories.Interfaces
{
    public interface IPropertyListingFactory
    {
        Result<PropertyListing> Create(int? id, string title, string description, decimal price);
    }

}
