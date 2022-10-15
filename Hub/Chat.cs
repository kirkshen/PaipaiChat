// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace paipaichat
{
    public class Chat : Hub
    {
        private IDistributedCache _cache;

        public async Task BroadcastMessage(string name, string message)
        {
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }
    }
}