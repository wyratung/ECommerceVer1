﻿using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Persistence
{
    public class OderContextSeed(Serilog.ILogger logger, OrderContext context)
    {
        public async Task InitializeAsync()
        {
            try
            {
                if (context.Database.IsSqlServer())
                {
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred while initializing OrderDb data");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred while seed OrderDb data");
                throw;
            }
        }


        public async Task TrySeedAsync()
        {
            if (!context.Orders.Any())
            {
                var orders = new List<OrderEntity>
            {
                new OrderEntity
                {
                    UserName = "customer1",
                    FirstName = "customer1",
                    LastName = "customer",
                    EmailAddress = "customer1@local.com",
                    ShippingAddress = "123 Main St, City, Country",
                    InvoiceAddress = "123 Main St, City, Country",
                    TotalPrice = 100.10m
                }
            };
                context.Orders.AddRange(orders);
                await Task.CompletedTask;
            }
        }
    }
}
