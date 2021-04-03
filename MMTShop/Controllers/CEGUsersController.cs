using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CEGUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEGUsers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CEGUsersController : ControllerBase
    {
       
        private readonly CEGUsersContext _context;

        public CEGUsersController(CEGUsersContext context) => _context = context;

 
        /// <summary>
        /// GET all addresses for a user
        /// </summary>
        [HttpGet("Users/{UserID}", Name = "GetUserAddresses")]
        public ActionResult<IEnumerable<UserAddresses>> GetUserAddresses(int UserID)
        {
            var result = _context.Addresses.Where(x => x.UserID==UserID).ToList();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// GET all users in the db
        /// </summary>
        [HttpGet( Name = "GetAllUsers")]
        public ActionResult<List<CEGUser>> GetAllUsers()
        {
             
            var result = _context.Users.ToList();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Get a single user
        /// </summary>
        [HttpGet("{UserID}", Name = "GetUser")]
        public ActionResult<IEnumerable<CEGUser>> GetUser(int UserID)
        {
            var result = _context.Users.Where(x => x.ID == UserID).ToList();
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        /// <summary>
        /// Add a new User
        /// </summary>
        [HttpPost( Name = "AddUser")]
        public ActionResult<CEGUser> AddUser( string firstname, string surname, DateTime dob)
        {
            CEGUser user = new CEGUser()
            {

                Firstname = firstname,
                Surname = surname,
                DOB = dob
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
            //return CreatedAtAction("GetUser", _context.Users.OrderByDescending(x => x.ID).FirstOrDefault().ID);
        }
        /// <summary>
        /// Add a new address for a user
        /// </summary>
        [HttpPost("Users/{UserID}", Name = "AddUserAddress")]
        public ActionResult<CEGUser> AddUserAddress( int UserID, DateTime startDate, DateTime endDate, string houseNumber,
            string postCode)
        {
            UserAddresses address = new UserAddresses()
            {
                UserID=UserID,
                StartDate = startDate,
                EndDate = endDate,
                HouseNumber = houseNumber,
                PostCode = postCode
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return Ok(address);
            //return CreatedAtAction("GetUserAddresses", userID);
        }       
        /// <summary>
        /// DELETE a user
        /// </summary>
        [HttpDelete("{UserID}", Name = "DeleteUser")] 
        public ActionResult<CEGUser> DeleteUser(int UserID)
        {
            var addresses = _context.Addresses.Where(x => x.UserID==UserID);

            if (addresses != null)
            {
                _context.Addresses.RemoveRange(addresses);
                _context.SaveChanges();
            }
            var user = _context.Users.Find(UserID);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }
        
        /// <summary>
        /// delete single address
        /// </summary>
        [HttpDelete("Users/{AddressID}", Name = "DeleteAddress")]
        public ActionResult<UserAddresses> DeleteAddress(int AddressID)
        {
            var address = _context.Addresses.Find(AddressID);

            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            _context.SaveChanges();

            return address;
        }


    }
}
