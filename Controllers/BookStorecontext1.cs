
using System.Collections;
using System.Reflection;

namespace Sprint_Week_1.Controllers
{
    internal class BookStorecontext
    {
        internal object inventory;
        internal object invetory;

        public IEnumerable Registers { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        internal void Update(Module module)
        {
            throw new NotImplementedException();
        }

        public static implicit operator BookStorecontext(BookStoreContext v)
        {
            throw new NotImplementedException();
        }
    }
}