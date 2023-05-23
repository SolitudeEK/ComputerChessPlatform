﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Management.Api
{
    [ApiController]
    [Route("management")]
    [Produces("application/json")]

    public class ManagementController : ControllerBase
    {
        private IManagement management { get; set; }
        private readonly string path;
        public ManagementController(IManagement management, IConfiguration configuration)
        {
            this.management = management;
            path = configuration.GetSection("pathToSave").Value;
        }

        [Route("newengines")]
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetEngines()
            => CreatedAtAction(nameof(GetEngines), new { engines = management.GetEngines() });

        [Route("engines")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetEnginesInUse()
            => CreatedAtAction(nameof(GetEnginesInUse), new { engines = management.GetEnginesInUse() });

        [Route("approve/{name}")]
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Approve(string name)
        {
            management.ApproveEngine(name);
            return Ok();
        }
        [Route("upload/{name}")]
        [HttpPost]
        public async Task<IActionResult> UploadEngine(IFormFile file, string name)
        {
            string filePath = Path.Combine(path, file.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            management.UploadEngine(name, path + file.FileName);
            return Ok();
        }
        [Route("download/{fileName}")]
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Download(string fileName)
        {
            var filePath = management.DownloadEngine(fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest();
            }
            return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", fileName);
        }

    }
}