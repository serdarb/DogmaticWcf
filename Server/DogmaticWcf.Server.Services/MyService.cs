using System;
using DogmaticWcf.Server.Contracts;

namespace DogmaticWcf.Server.Services
{
    public class MyService : IMyService
    {
        public string DoSomething(MyDto data)
        {
            return string.Format("I did something at {0} with {1}", DateTime.Now, data.MyProperty);
        }
    }
}