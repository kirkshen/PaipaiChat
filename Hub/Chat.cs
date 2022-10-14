// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.SignalR;

namespace paipaichat
{
    public class Chat : Hub
    {
        // private readonly EFContext _context;
        //private readonly RedisCache _cache;

        // public Chat(IDistributedCache cacheProvider){
        //     // _context = context;
        //     _cache = new RedisCache(cacheProvider);
        // }

        public async Task BroadcastMessage(string name, string message)
        {
            //var expected = DateTimeOffset.Now - TimeSpan.FromMinutes(1);
            await Clients.All.SendAsync("broadcastMessage", name, message);
            
            //await _cache.Set(name,message, new DistributedCacheEntryOptions().SetAbsoluteExpiration(expected));
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }
    }
}