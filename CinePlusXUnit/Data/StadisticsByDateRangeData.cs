using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CinePlusXUnit.Data
{
    public class StadisticsByDateRangeData: IEnumerable<object[]>
    {


        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { default(DateTime), DateTime.Now };
            yield return new object[] { default(DateTime), default(DateTime) };
            yield return new object[] { DateTime.Now, default(DateTime) };
            yield return new object[] { DateTime.Now, DateTime.Now };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
