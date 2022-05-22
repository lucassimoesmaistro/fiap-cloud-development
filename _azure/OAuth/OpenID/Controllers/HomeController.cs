using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OpenID.Models;

namespace OpenID.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        readonly ITokenAcquisition _tokenAcquisition;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITokenAcquisition tokenAcquisition)
        {
            this._tokenAcquisition = tokenAcquisition;
        }
        

        public async Task<IActionResult> Index()
        {
            string[] scopes = new string[] { "user.read" };
            string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
            ViewBag.token = accessToken;
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
