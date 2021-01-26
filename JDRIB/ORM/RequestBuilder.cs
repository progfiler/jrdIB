using System;
using System.Collections.Generic;
using System.Text;

namespace JDRIB.ORM
{
    class RequestBuilder
    {
        public StringBuilder request = new StringBuilder();
        public RequestBuilder() { }

        internal RequestBuilder Select(params string[] values)
        {
            request.Append("SELECT ");
            if (values.Length > 0)
            {
                foreach (string value in values)
                {
                    request.Append($"{value},");
                }
                request.Remove((request.Length - 1), 1);
            }
            else
            {
                request.Append("*");
            }
            return this;
        }

        internal string Get()
        {
            return request.ToString();
        }

        internal RequestBuilder Where(string key, dynamic value, string type = "=")
        {
            request.Append($"WHERE {key} {type} {value}");
            return this;
        }

        internal RequestBuilder From(string table)
        {
            request.Append($" FROM {table} ");
            return this;
        }
    }
}
