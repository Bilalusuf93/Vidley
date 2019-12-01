using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Vidley.Dtos;
using Vidley.Models;
using System.Data.Entity;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Vidley.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //get /api/cutomer
        public IHttpActionResult GetCustomer()
        {
            var customerDts = _context
                .Customers.Include(x => x.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDtos>);
            return Ok(customerDts);
        }
        //get /api/cutomer/1
        public CustomerDtos GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDtos>(customer) ;
        }
        [HttpPost]
        public IHttpActionResult CretaeCustomer(CustomerDtos customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDtos, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }
        // PUT api/cistomes/1
        [System.Web.Http.HttpPut]
        public void UpdateCustomer(int id,CustomerDtos customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDB);

         
            _context.SaveChanges();
        }

        [System.Web.Mvc.HttpDelete]
        public void DeleteCustomer (int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
