using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CinePlus.Test.Mocks
{
    public class FakeClaimsIdentity : ClaimsIdentity
    {
        public override string Name { get; }
        public FakeClaimsIdentity(string name)
        {
            Name = name;
        }
    }
}
