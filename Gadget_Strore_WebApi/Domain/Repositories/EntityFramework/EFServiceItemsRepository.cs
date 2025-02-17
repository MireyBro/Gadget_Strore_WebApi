﻿using System;
using Gadget_Strore_WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Gadget_Strore_WebApi.Domain.Repositories.Abstract;

namespace Gadget_Strore_WebApi.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteServiceItem(Guid id)
        {

            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();

        }
    }
}
