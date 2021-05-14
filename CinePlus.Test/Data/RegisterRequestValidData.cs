using CinePlus.Models;
using System.Collections;
using System.Collections.Generic;

namespace CinePlus.Test
{
    internal class RegisterRequestValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new RegisterModelRequest
                {
                    userName = "valid",
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
                    password = "valid",
                    email = "valid",
                    lastName = "valid",
                    name = "valid",
                    role = Roles.Client
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}