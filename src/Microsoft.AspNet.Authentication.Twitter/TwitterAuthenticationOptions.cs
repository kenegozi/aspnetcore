// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using Microsoft.AspNet.Http;

namespace Microsoft.AspNet.Authentication.Twitter
{
    /// <summary>
    /// Options for the Twitter authentication middleware.
    /// </summary>
    public class TwitterAuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterAuthenticationOptions"/> class.
        /// </summary>
        public TwitterAuthenticationOptions()
        {
            AuthenticationScheme = TwitterAuthenticationDefaults.AuthenticationScheme;
            Caption = AuthenticationScheme;
            CallbackPath = new PathString("/signin-twitter");
            BackchannelTimeout = TimeSpan.FromSeconds(60);
        }

        /// <summary>
        /// Gets or sets the consumer key used to communicate with Twitter.
        /// </summary>
        /// <value>The consumer key used to communicate with Twitter.</value>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret used to sign requests to Twitter.
        /// </summary>
        /// <value>The consumer secret used to sign requests to Twitter.</value>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with Twitter.
        /// </summary>
        /// <value>
        /// The back channel timeout.
        /// </value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        /// The HttpMessageHandler used to communicate with Twitter.
        /// This cannot be set at the same time as BackchannelCertificateValidator unless the value 
        /// can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        /// Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned.
        /// The middleware will process this request when it arrives.
        /// Default value is "/signin-twitter".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        /// Gets or sets the authentication scheme corresponding to the middleware
        /// responsible of persisting user's identity after a successful authentication.
        /// This value typically corresponds to a cookie middleware registered in the Startup class.
        /// When omitted, <see cref="SharedAuthenticationOptions.SignInScheme"/> is used as a fallback value.
        /// </summary>
        public string SignInScheme { get; set; }

        /// <summary>
        /// Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<RequestToken> StateDataFormat { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITwitterAuthenticationEvents"/> used to handle authentication events.
        /// </summary>
        public ITwitterAuthenticationEvents Events { get; set; }

        /// <summary>
        /// Defines whether access tokens should be stored in the
        /// <see cref="ClaimsPrincipal"/> after a successful authentication.
        /// This property is set to <c>false</c> by default to reduce
        /// the size of the final authentication cookie.
        /// </summary>
        public bool SaveTokensAsClaims { get; set; }
    }
}
