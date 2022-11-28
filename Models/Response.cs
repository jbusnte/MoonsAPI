using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoonsAPI.Models
{
    public class Response : IHttpActionResult
    {
        public HttpStatusCode StatusCode;
        public string Description;

        public Response(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Description = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(Description)
            };
            return Task.FromResult(response);
        }
    }
}
