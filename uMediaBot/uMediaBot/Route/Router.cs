using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot
{
    public class Router
    {
        private readonly List<Route> _routes = new List<Route>();

        public Router Bind(string command, Action action, string name)
        {
  
            _routes.Add(
                new Route() {
                    Name = name,
                    RawRoute = command,
                    Handler = action
                }
            );
            return this;
        }
    }
}
