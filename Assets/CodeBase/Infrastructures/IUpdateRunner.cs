using System;

namespace CodeBase.Infrastructures
{
    public interface IUpdateRunner
    { 
        event Action Updated;
    }
}