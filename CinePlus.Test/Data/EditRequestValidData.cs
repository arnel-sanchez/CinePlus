using CinePlus.Models;
using System.Collections;
using System.Collections.Generic;

namespace CinePlus.Test
{
    internal class EditRequestValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new EditModelRequest
                {
                    userId = "valid",
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