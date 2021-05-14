using CinePlus.Models;
using System.Collections;
using System.Collections.Generic;

namespace CinePlus.Test
{
    internal class RegisterRequestInvalidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new RegisterModelRequest
                {
                    userName = "invalid",
                    password = "valid",
                    email = "valid",
                    lastName = "valid",
                    name = "valid",
                    role = Roles.Partner
                }
            };
            yield return new object[] {
                new RegisterModelRequest
                {
                    userName = "valid",
                    password = "invalid",
                    email = "valid",
                    lastName = "valid",
                    name = "valid",
                    role = Roles.Partner
                }
            };
            yield return new object[] {
                new RegisterModelRequest
                {
                    userName = "valid",
                    password = "valid",
                    email = "invalid",
                    lastName = "valid",
                    name = "valid",
                    role = Roles.Partner
                }
            };
            yield return new object[] {
                new RegisterModelRequest
                {
                    userName = "valid",
                    password = "valid",
                    email = "valid",
                    lastName = "valid",
                    name = "valid",
                    role = "invalid"
                }
            };
            yield return new object[] {
                new RegisterModelRequest
                {
                    userName = null,
                    password = null,
                    email = null,
                    lastName = null,
                    name = null,
                    role = Roles.Partner
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}