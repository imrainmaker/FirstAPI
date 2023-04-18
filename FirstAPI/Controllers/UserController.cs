using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Models;
using BLL.Interfaces;
using DAL.Models.DTO;
using DAL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string?>> Login(UserLoginDTO login)
        {
            string? token = await _userService.Login(login);
            return token is not null ? Ok(token) : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            return Ok( await _userService.GetAll());
        }

        [HttpGet("email")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetByEmail(string email)
        {
            

            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.GetByEmail(email);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.GetById(id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpGet("pseudo")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetByPseudo(string pseudo)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.GetByPseudo(pseudo);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }


        [HttpPost("create")]
        public async Task<ActionResult<UserViewModel>> Add(UserAddDTO userDTO)
        {

            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.Add(userDTO);
                return user is not null ? Ok(user) : Problem();
            }

            return BadRequest();

        }

        [HttpPatch("editprofil/{id}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> UpdateProfil(UserProfilDTO profil, int id)
        {
            if(id.ToString() != User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.UpdateUserProfil(profil, id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpPatch("password/{id}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> UpdatePassword(UserPwdDTO password, int id)
        {
            if (id.ToString() != User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.UpdatePassword(password, id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpPatch("phone/{id}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> UpdatePhone(UserPhoneDTO phone, int id)
        {
            if (id.ToString() != User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.UpdatePhone(phone, id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

     
        [HttpPatch("role/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserViewModel>> UpdateRole(UserRoleDTO role, int id)
        {
            if (ModelState.IsValid)
            {
                UserViewModel? user = await _userService.UpdateRole(role, id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _userService.Delete(id) ? Ok() : BadRequest();
        }

    }
}
