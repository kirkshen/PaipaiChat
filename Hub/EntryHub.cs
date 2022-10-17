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
            //get data according to the connectionId
            /*var entryString = System.Text.Json.JsonSerializer.Serialize(entries);*/

            //TODO real data 
            //TODO dynamic size
            //string entryJson = File.ReadAllText("..\\DemiData\\NFEList.json");
            
            /*1st param: a function name; 2nd param: data to pass */
            //!Trigger the event! on client, & pass parameter
            await Clients.All.SendAsync("RecieveNFEPush", "no");
        }
        /*
         * possibly hub protocal: JSON 
         */
        /** TODO Redis Project to do Redis job
         * TODO Redis call SignalR API
          TODO Redis */
    }
}