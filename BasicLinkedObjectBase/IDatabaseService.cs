using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLinkedObjectBase
{
    public interface IDatabaseService
    {
        public void Add<T>(T obj);

        public void Update<T>(T obj);

        public List<T> Query<T>();

        public void Delete<T>(T obj);

        public void Delete<T>(string id);
    }
}
