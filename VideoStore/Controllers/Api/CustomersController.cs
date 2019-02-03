using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Dtos;
using VideoStore.Models;
using System.Data.Entity;

namespace VideoStore.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }


        //Get/Api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customersDto = context.Customers
                .Include(c=> c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customers,CustomersDto>);
            return Ok(customersDto);
        }
        //Get/Api/Customes/id
        public IHttpActionResult GetCustomers(int id)
        {
            var customers = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return NotFound();
            return Ok(Mapper.Map<Customers, CustomersDto>(customers));
        }

        //Post/Api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageData)]
        public IHttpActionResult CreateCustomers(CustomersDto customersDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomersDto, Customers>(customersDto);

            context.Customers.Add(customer);
            context.SaveChanges();
            customersDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customersDto);

        }
        //post /api/customers/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageData)]
        public void UpdateCustomers(int id, CustomersDto customersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customersDto, CustomerInDb);           

            context.SaveChanges();
        }
        //delete /api/customers/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageData)]
        public void DelteCustomres(int id)
        {
            var CustomerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Customers.Remove(CustomerInDb);
            context.SaveChanges();
        }
    }
}
