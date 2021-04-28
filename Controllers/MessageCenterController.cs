using GS1US.Framework.API.Controllers.BaseControllers;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.API.Security;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.DAL.Services.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Controllers
{   
    public class MessageCenterController : BaseNoAuthController
    {
        private const string PRODUCT_READ_SCOPE = "messagecenter.read";
        private const string PRODUCT_WRITE_SCOPE = "product.write";

        private IProductControllerService ProductControllerService { get; }
        private IMessageCenterControllerService MessageCenterService { get; }

        public MessageCenterController(IProductControllerService productControllerService,
                                    IMessageCenterControllerService messageCenterService,
                                    IGS1USAppInsightsLogger logger): base(logger)
        {
            this.ProductControllerService = productControllerService;
            this.MessageCenterService = messageCenterService;
        }
               
        [HttpGet]
        [Route("GetMessageCenterCounts")]
        public IActionResult GetMessageCenterCounts(string userId = null)
        {
            var msgCenterCounts = this.MessageCenterService.GetMessageCenterCountsForUser(userId);

            if (msgCenterCounts == null)
            {
                return NotFound();
            }

            return Ok(msgCenterCounts);
        }

        [HttpGet]
        [B2CScope(ScopeName = MessageCenterController.PRODUCT_READ_SCOPE)]
        [Route("GetMessageCenterCountsAuth")]
        public IActionResult GetMessageCenterCountsAuth(string userId = null)
        {
            var msgCenterCounts = this.MessageCenterService.GetMessageCenterCountsForUser(userId);

            if (msgCenterCounts == null)
            {
                return NotFound();
            }

            return Ok(msgCenterCounts);
        }
    }
}
