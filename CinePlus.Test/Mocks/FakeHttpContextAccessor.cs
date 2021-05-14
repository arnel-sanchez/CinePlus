using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinePlus.Test.Mocks
{
    public class FakeHttpContextAccessor : IHttpContextAccessor
    {
        private FakeHttpContext httpContext { get; set; }
        public HttpContext HttpContext { get { return httpContext; } set => throw new NotImplementedException(); }
    }
}
