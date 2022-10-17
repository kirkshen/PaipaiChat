// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Microsoft.AspNetCore.SignalR;
using paipaichat.Models;

namespace paipaichat
{
//create class 
    public class Entry: Hub{
        /*TEST push list of feed
         *  @params array of entries
         */
        public async Task PushFeed(string connectionId /*NonRefungibleEntry[] entries*/)
        {
            //TODO real data 
            //TODO dynamic size
            //DEBUG push NFE obj
            await Clients.All.SendAsync("RecieveNFEPush", connectionId);
        }
        /*
         * possibly hub protocal: JSON 
         */
        /** TODO Redis Project to do Redis job
         * TODO Redis call SignalR API
          TODO Redis */
    }
}