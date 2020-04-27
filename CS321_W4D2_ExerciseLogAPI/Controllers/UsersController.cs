﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var user = _userService
                .GetAll();
            return Ok(user);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService
                .Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            try
            {
                _userService.Add(user.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = user.Id }, user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel user)
        {
            user.Id = id;
            var createUser = _userService.Update(user.ToDomainModel());
            if (createUser == null) return NotFound();
            return Ok(createUser);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            _userService.Remove(user);
            return NoContent();
        }
    }
}
