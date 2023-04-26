using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Http;
using Renci.SshNet;
using Renci.SshNet.Common;
using ServiceStack;

namespace ProjectForPartnerSouth
{
    internal class SSH_Connect
    {
        static public string IP_ssh_server { get; set; }
        static public int port_ssh_server { get; set; }
        static public string ssh_user { get; set; }
        static public string ssh_password { get; set; }
    }
}
