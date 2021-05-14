using CinePlus.Models;
using System.Collections;
using System.Collections.Generic;

namespace CinePlus.Test
{
    internal class EditRequestInvalidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new EditModelRequest
                {
                    userId = "invalid",
                    password = "valid"
                }
            };
            yield return new object[] {
                new EditModelRequest
                {
                    userId = "valid",
                    userName = "valid",
                    password = "valid"
                }
            };
            yield return new object[] {
                new EditModelRequest
                {
                    userId = "valid",
                    password = "invalid"
                }
            };
            yield return new object[] {
                new EditModelRequest
                {
                    userId = null,
                    password = "valid"
                }
            };
            yield return new object[] {
                new EditModelRequest
                {
                    userId = "valid",
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