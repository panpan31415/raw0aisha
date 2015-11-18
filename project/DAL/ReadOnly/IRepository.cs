using System;
using System.Collections.Generic;

namespace project.DAL
{
    public interface IReadOlnyRepository<T> where T :class ,new()
    {
        /// <summary>
        /// Get records from database as a collection
        /// </summary>
        /// <param name="limit">specify the size of the returned collection </param>
        /// <param name="offset">specify the start point of cursor in a table that will be selected.</param>
        /// <returns>a collection of records that selected from database </returns>
        IEnumerable<T> getAll(int limit = 10, int offset = 0);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribut_value"></param>
        /// <returns></returns>
        IEnumerable<T> getBySingleAttribute(Tuple<string, object> attribut_value);
    }
}