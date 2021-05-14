using System.Collections;
using System.Collections.Generic;
using CinePlus.Models;

namespace CinePlus.Test
{
    internal class LoginRequestInvalidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new LoginModelRequest
                {
                    username = "invalid",
                    password = "valid"
                }
            };
            yield return new object[] {
                new LoginModelRequest
                {
                    username = "valid",
                    password = "invalid"
                }
            };
            yield return new object[] {
                new LoginModelRequest
                {
                    username = null,
                    password = "valid"
                }
            };
            yield return new object[] {
                new LoginModelRequest
                {
                    username = "valid",
                    password = null
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}