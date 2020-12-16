using System.Collections.Generic;

namespace Ioasys.Api.HATEOAS
{
    public class HATEOAS
    {
        public string url;

        public string protocol = "https://";

        public List<Link> actions = new List<Link>();

        public HATEOAS (string url, string protocol)
        {
            this.url = url;
            this.protocol = protocol;
        }

        public void AddAction(string rel, string method)
        {
            // https://localhost:5001/ioasys/v1/"
            actions.Add(new Link(this.protocol + this.url,rel,method));
        }

        public Link[] GetActions()
        {
            return actions.ToArray();
        }

    }
}
