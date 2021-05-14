using System.Collections;
using System.Collections.Generic;
using CinePlus.Models;

namespace CinePlus.Test
{
    internal class LoginRequestValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new LoginModelRequest
                {
                    username = "valid",
                    password = "valid"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}