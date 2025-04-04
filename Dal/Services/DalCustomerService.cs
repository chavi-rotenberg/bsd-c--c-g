﻿//בס"ד

using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalCustomerService : IDalCustomer
    {
        dbcontext dbcontext;
        public DalCustomerService(dbcontext data)
        {
            dbcontext = data;
        }

        public void Create(Customer customer)
        {
            dbcontext.Customers.Add(customer);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
             var clist = dbcontext.Customers.ToList();
            var olist =dbcontext.Orders.ToList();
            dbcontext.Orders.Remove(olist.Find(x => x.CustomerId == id));

            dbcontext.Customers.Remove(clist.Find(x => x.InstituteId == id));
            dbcontext?.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return dbcontext.Customers.Include(x => x.Orders).ToList();
        }

        public dbcontext GetDbcontext()
        {
            return dbcontext;
        }

        public Customer? GetById(int id)
        {
            return GetAll().Find(x => x.InstituteId == id);
        }

        public void Update(Customer customer)
        {
            
            //dbcontext.Customers.Update(customer);
            var clist = dbcontext.Customers.ToList();
            var x=clist.Find(x => x.InstituteId == customer.InstituteId);
           if (x != null) {
                // dbcontext.Customers.Update(x);

                x.Email = customer.Email;
                x.City = customer.City;
                x.Amount = customer.Amount;
                x.Mobile = customer.Mobile;
                x.Community = customer.Community;
                x.ContactName = customer.ContactName;
                x.InstituteName = customer.InstituteName;
                x.ContactPhone = customer.ContactPhone;
                x.Fax = customer.Fax;
                x.Due = customer.Due;

                // all file
                dbcontext.SaveChanges();
            }
        }
    }
}
