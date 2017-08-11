﻿// Author: Mike Mollick <mike@neverbounce.com>
//
// Copyright (c) 2017 NeverBounce
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Threading.Tasks;
using NeverBounce.Models;
using NeverBounce.Utilities;
using Newtonsoft.Json;

namespace NeverBounce.Services
{
    public class SingleService
    {
        protected string _apiKey;

        protected IHttpClient _client;

        protected string _host;

        public SingleService(IHttpClient Client, string ApiKey, string Host = null)
        {
            _client = Client;
            _apiKey = ApiKey;

            // Accept debug host
            if (Host != null)
                _host = Host;
        }

        /// <summary>
        ///     Single verification allows you verify individual emails and gather additional information pertaining to the email.
        ///     See: "https://developers.neverbounce.com/v4.0/reference#single-check"
        /// </summary>
        /// <param name="model"> SingleRequestModel</param>
        /// <returns>SingleResponseModel</returns>
        public async Task<SingleResponseModel> Check(SingleRequestModel model)
        {
            var client = new NeverBounceHttpClient(_client, _apiKey, _host);
            var result = await client.MakeRequest("GET", "/single/check", model);
            return JsonConvert.DeserializeObject<SingleResponseModel>(result);
        }
    }
}