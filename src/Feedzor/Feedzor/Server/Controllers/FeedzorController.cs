﻿using Feedzor.Server.Services;
using Feedzor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedzor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FeedzorController : ControllerBase
    {
        private readonly ILogger<FeedzorController> _logger;
        private readonly IFeedzorService _feedzorService;

        public FeedzorController(ILogger<FeedzorController> logger, IFeedzorService feedzorService)
        {
            _logger = logger;
            _feedzorService = feedzorService;
        }

        [HttpGet]
        public async Task<IEnumerable<FeedSource>> Get()
        {
            var result = await _feedzorService.LoadFeedSources("ema@emanuele.com");

            return result;
        }

        [HttpGet("GetRssById/{feedId}")]
        public async Task<List<FeedItem>> GetById(Guid feedId)
        {
            var result = await _feedzorService.LoadFeedItems(feedId.ToString());

            return result;
        }
    }
}