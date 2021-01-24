using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Services.Interface
{
    public interface IContextService
    {
        public void Push(int contextId);
        public int GetCurrentContext();
        public void Clear();
    }
}
