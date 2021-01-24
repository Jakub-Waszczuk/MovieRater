using MovieRater.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class ContextService : IContextService
    {
        private int? Context;

        public ContextService()
        {
        }

        public void Clear()
        {
            Context = null;
        }

        public int GetCurrentContext()
        {
            if (Context.HasValue)
                return Context.Value;
            else
                return 0;
        }

        public void Push(int contextId)
        {
            Context = contextId;
        }
    }
}
