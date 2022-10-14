// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.SignalR;
using paipaichat.Models;


namespace paipaichat
{
//create class 
    public class Entry: Hub{
        /*TEST push list of feed
            name: sender name
            string: content tp send
         */
        public async Task PushFeed(NonRefungibleEntry entry)
        {
            /*1st param: a function name
             2nd param: parameter to pass to the */
            await Clients.All.SendAsync("Reciew", entry);
        }
    }
}