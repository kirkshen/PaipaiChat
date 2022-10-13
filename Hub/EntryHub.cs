// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.SignalR;

namespace paipaichat
{
//create class 
    public class EntryHub: Hub{
        /*TEST push list of feed
            name: sender name
            string: content tp send
         */
        public void PushFeed(string name, string message)
        {
            Clients.All.SendAsync("FeedList", name, message);
        }
    }
}