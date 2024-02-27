
using System.Collections.Generic;
namespace Infrastructure.Data
{

    public class DB<T>
    {
        public List<T> db { get; set; } = new List<T>();

    }
}
