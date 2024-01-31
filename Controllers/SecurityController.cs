using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SessionNine.Application.Models.Security;
using SessionNine.Application.Services;
using SessionNine.Domains.Entity;
using SessionNine.Infrastructure.Data.Core;
using SessionNine.Infrastructure.Data.Repositories;

namespace SessionNine.Controllers
{
    [ApiController]
    [Route("Security")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityRepository _repository;
        private readonly IApplicationServices _applicationServices;
        private readonly IMapper _mapper;

        public SecurityController(
            ISecurityRepository repository,
            IMapper mapper,
            IApplicationServices applicationServices
        )
        {
            _repository = repository;
            _mapper = mapper;
            _applicationServices = applicationServices;
        }

        #region Methods

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddNewUser([FromBody] CreateSecurity newUser)
        {
            // check username is uniq in database because that is nathional code .

            var newUsers = _mapper.Map<Security>(newUser);
            // var exists = await _repository.ExistAsync<string>(a => a.UserName , newUsers.UserName.ToString() );

            // if (exists)
            // {
            //     return BadRequest(new { Status = "Error", Message = "National code already exists" });
            // }

            var newPassword = _applicationServices.HashPassword(newUsers.Password);
            newUsers.Password = newPassword;
            await _repository.AddAsync(newUsers);

            return Ok();
        }

        // [HttpGet("GiveListUser")]
        // public async Task<ActionResult<IEnumerable<ShowSecurityList>>> GiveUserList()
        // {
        //     // var list = await _repository.GetValuesAll();
        //     // var finnaly = _mapper.Map<IEnumerable<ShowSecurityList>>(list);
        //     // return Ok(finnaly);
        // }


        #endregion

    }
}
