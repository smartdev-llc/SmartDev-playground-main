using Microsoft.AspNetCore.Mvc;
using SmartDev.BookManagement.Apis.Models;
using SmartDev.BookManagement.Business;
using SmartDev.BookManagement.Entities;
using SmartDev.BookManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDev.BookManagement.Apis.Controllers
{
    /// <summary>
    /// The book controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{api-version:apiVersion}/userbook")]
    public class UserBookRelationController : Controller
    {
        private readonly IUserBookRelationService _userBookRelationService;

        public UserBookRelationController(IUserBookRelationService userBookRelationService)
        {
            _userBookRelationService = userBookRelationService;
        }

        //TODO: we should use userId base on logined user.

        [HttpGet("/v{api-version:apiVersion}/users/{userId}/books")]
        public async Task<IEnumerable<BookEntity>> GetUserBooks(Guid userId, [FromQuery] RelationTypeEnum? relationType)
        {
            return await _userBookRelationService.GetUserBooks(userId, relationType);
        }

        [HttpPost("/v{api-version:apiVersion}/users/{userId}/books")]
        public async Task AddBookToUserList(Guid userId, [FromBody] UserBookRelationRequestModel requestModel)
        {
            await _userBookRelationService.AddBookToUserList(userId, requestModel.BookId, requestModel.RelationType);
        }
    }
}
