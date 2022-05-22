using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;


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
            string[] scopes = new string[] { "user.read" , "https://storage.azure.com/user_impersonation" };
            Uri storage_uri = new Uri("https://demostore40000.blob.core.windows.net");
            var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);
            TokenCredential _tokenCredential = new TokenCredential(accessToken);
            StorageCredentials storageCredentials = new StorageCredentials(_tokenCredential);
            CloudBlockBlob blob =
        new CloudBlockBlob(
            new Uri("https://demostore40000.blob.core.windows.net/data/sample.txt"),
            storageCredentials);
            await blob.UploadTextAsync("This is a sample file");
            return View();
        }

        public IActionResult Logout()
        {
            
            return SignOut();                
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LoggedOut()
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
