﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//引用命名空间
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using NFineCore.WebApi.Models;

namespace NFineCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private JwtSettings _jwtSettings;

        public AuthorizeController(IOptions<JwtSettings> _jwtSettingsAccesser)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
        }

        [HttpPost]
        public IActionResult Token([FromBody]LoginViewModel viewModel)
        {
            if (ModelState.IsValid)//判断是否合法
            {
                if (!(viewModel.Username == "flyang" && viewModel.Password == "123456"))//判断账号密码是否正确
                {
                    return BadRequest();
                }


                var claim = new Claim[]{
                    new Claim(ClaimTypes.Name,"flyang"),
                    new Claim(ClaimTypes.Role,"admin")
                };

                //对称秘钥
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                //签名证书(秘钥，加密算法)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //生成token  [注意]需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
                var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claim, DateTime.Now, DateTime.Now.AddSeconds(30), creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }

            return BadRequest();
        }
    }
}
