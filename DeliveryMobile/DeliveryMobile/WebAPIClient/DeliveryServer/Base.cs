﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryMobile.WebAPIClient.DeliveryServer
{
    public class Base
    {
        public enum PRE_SERVER_RETURN_CODE
        {
            #region General Group
            SUCCESS = 0,
            FAIL,
            COMMAND_NOT_FOUND,
            TOKEN_INVALID_OR_EXPIRED,
            ACCESS_DENIED,
            INVALID_PARAM,
            API_NOT_SUPPORT,
            INCOMPATIBLE_VERSION,
            PLATFROM_NOT_SUPPORT,
            INTERNAL_ERROR,
            INVALID_DATA,

            /// <summary>Equivalent to HTTP status 100. <see cref="F:System.Net.HttpStatusCode.Continue" /> indicates that the client can continue with its request.</summary>
            Continue = 100,
            /// <summary>Equivalent to HTTP status 101. <see cref="F:System.Net.HttpStatusCode.SwitchingProtocols" /> indicates that the protocol version or protocol is being changed.</summary>
            SwitchingProtocols = 101,
            /// <summary>Equivalent to HTTP status 102. <see cref="F:System.Net.HttpStatusCode.Processing" /> indicates that the server has accepted the complete request but hasn't completed it yet.</summary>
            Processing = 102,
            /// <summary>Equivalent to HTTP status 103. <see cref="F:System.Net.HttpStatusCode.EarlyHints" /> indicates to the client that the server is likely to send a final response with the header fields included in the informational response.</summary>
            EarlyHints = 103,
            /// <summary>Equivalent to HTTP status 200. <see cref="F:System.Net.HttpStatusCode.OK" /> indicates that the request succeeded and that the requested information is in the response. This is the most common status code to receive.</summary>
            Ok = 200,
            /// <summary>Equivalent to HTTP status 201. <see cref="F:System.Net.HttpStatusCode.Created" /> indicates that the request resulted in a new resource created before the response was sent.</summary>
            Created = 201,
            /// <summary>Equivalent to HTTP status 202. <see cref="F:System.Net.HttpStatusCode.Accepted" /> indicates that the request has been accepted for further processing.</summary>
            Accepted = 202,
            /// <summary>Equivalent to HTTP status 203. <see cref="F:System.Net.HttpStatusCode.NonAuthoritativeInformation" /> indicates that the returned meta information is from a cached copy instead of the origin server and therefore may be incorrect.</summary>
            NonAuthoritativeInformation = 203,
            /// <summary>Equivalent to HTTP status 204. <see cref="F:System.Net.HttpStatusCode.NoContent" /> indicates that the request has been successfully processed and that the response is intentionally blank.</summary>
            NoContent = 204,
            /// <summary>Equivalent to HTTP status 205. <see cref="F:System.Net.HttpStatusCode.ResetContent" /> indicates that the client should reset (not reload) the current resource.</summary>
            ResetContent = 205,
            /// <summary>Equivalent to HTTP status 206. <see cref="F:System.Net.HttpStatusCode.PartialContent" /> indicates that the response is a partial response as requested by a GET request that includes a byte range.</summary>
            PartialContent = 206,
            /// <summary>Equivalent to HTTP status 207. <see cref="F:System.Net.HttpStatusCode.MultiStatus" /> indicates multiple status codes for a single response during a Web Distributed Authoring and Versioning (WebDAV) operation. The response body contains XML that describes the status codes.</summary>
            MultiStatus = 207,
            /// <summary>Equivalent to HTTP status 208. <see cref="F:System.Net.HttpStatusCode.AlreadyReported" /> indicates that the members of a WebDAV binding have already been enumerated in a preceding part of the multistatus response, and are not being included again.</summary>
            AlreadyReported = 208,
            /// <summary>Equivalent to HTTP status 226. <see cref="F:System.Net.HttpStatusCode.IMUsed" /> indicates that the server has fulfilled a request for the resource, and the response is a representation of the result of one or more instance-manipulations applied to the current instance.</summary>
            IMUsed = 226,
            /// <summary>Equivalent to HTTP status 300. <see cref="F:System.Net.HttpStatusCode.Ambiguous" /> indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response. <c>Ambiguous</c> is a synonym for <c>MultipleChoices</c>.</summary>
            Ambiguous = 300,
            /// <summary>Equivalent to HTTP status 300. <see cref="F:System.Net.HttpStatusCode.MultipleChoices" /> indicates that the requested information has multiple representations. The default action is to treat this status as a redirect and follow the contents of the Location header associated with this response. <c>MultipleChoices</c> is a synonym for <c>Ambiguous</c>.</summary>
            MultipleChoices = 300,
            /// <summary>Equivalent to HTTP status 301. <see cref="F:System.Net.HttpStatusCode.Moved" /> indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. <c>Moved</c> is a synonym for <c>MovedPermanently</c>.</summary>
            Moved = 301,
            /// <summary>Equivalent to HTTP status 301. <see cref="F:System.Net.HttpStatusCode.MovedPermanently" /> indicates that the requested information has been moved to the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. <c>MovedPermanently</c> is a synonym for <c>Moved</c>.</summary>
            MovedPermanently = 301,
            /// <summary>Equivalent to HTTP status 302. <see cref="F:System.Net.HttpStatusCode.Found" /> indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. <c>Found</c> is a synonym for <c>Redirect</c>.</summary>
            Found = 302,
            /// <summary>Equivalent to HTTP status 302. <see cref="F:System.Net.HttpStatusCode.Redirect" /> indicates that the requested information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will use the GET method. <c>Redirect</c> is a synonym for <c>Found</c>.</summary>
            Redirect = 302,
            /// <summary>Equivalent to HTTP status 303. <see cref="F:System.Net.HttpStatusCode.RedirectMethod" /> automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET. <c>RedirectMethod</c> is a synonym for <c>SeeOther</c>.</summary>
            RedirectMethod = 303,
            /// <summary>Equivalent to HTTP status 303. <see cref="F:System.Net.HttpStatusCode.SeeOther" /> automatically redirects the client to the URI specified in the Location header as the result of a POST. The request to the resource specified by the Location header will be made with a GET. <c>SeeOther</c> is a synonym for <c>RedirectMethod</c>.</summary>
            SeeOther = 303,
            /// <summary>Equivalent to HTTP status 304. <see cref="F:System.Net.HttpStatusCode.NotModified" /> indicates that the client's cached copy is up to date. The contents of the resource are not transferred.</summary>
            NotModified = 304,
            /// <summary>Equivalent to HTTP status 305. <see cref="F:System.Net.HttpStatusCode.UseProxy" /> indicates that the request should use the proxy server at the URI specified in the Location header.</summary>
            UseProxy = 305,
            /// <summary>Equivalent to HTTP status 306. <see cref="F:System.Net.HttpStatusCode.Unused" /> is a proposed extension to the HTTP/1.1 specification that is not fully specified.</summary>
            Unused = 306,
            /// <summary>Equivalent to HTTP status 307. <see cref="F:System.Net.HttpStatusCode.RedirectKeepVerb" /> indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method. <c>RedirectKeepVerb</c> is a synonym for <c>TemporaryRedirect</c>.</summary>
            RedirectKeepVerb = 307,
            /// <summary>Equivalent to HTTP status 307. <see cref="F:System.Net.HttpStatusCode.TemporaryRedirect" /> indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method. <c>TemporaryRedirect</c> is a synonym for <c>RedirectKeepVerb</c>.</summary>
            TemporaryRedirect = 307,
            /// <summary>Equivalent to HTTP status 308. <see cref="F:System.Net.HttpStatusCode.PermanentRedirect" /> indicates that the request information is located at the URI specified in the Location header. The default action when this status is received is to follow the Location header associated with the response. When the original request method was POST, the redirected request will also use the POST method.</summary>
            PermanentRedirect = 308,
            /// <summary>Equivalent to HTTP status 400. <see cref="F:System.Net.HttpStatusCode.BadRequest" /> indicates that the request could not be understood by the server. <see cref="F:System.Net.HttpStatusCode.BadRequest" /> is sent when no other error is applicable, or if the exact error is unknown or does not have its own error code.</summary>
            BadRequest = 400,
            /// <summary>Equivalent to HTTP status 401. <see cref="F:System.Net.HttpStatusCode.Unauthorized" /> indicates that the requested resource requires authentication. The WWW-Authenticate header contains the details of how to perform the authentication.</summary>
            Unauthorized = 401,
            /// <summary>Equivalent to HTTP status 402. <see cref="F:System.Net.HttpStatusCode.PaymentRequired" /> is reserved for future use.</summary>
            PaymentRequired = 402,
            /// <summary>Equivalent to HTTP status 403. <see cref="F:System.Net.HttpStatusCode.Forbidden" /> indicates that the server refuses to fulfill the request.</summary>
            Forbidden = 403,
            /// <summary>Equivalent to HTTP status 404. <see cref="F:System.Net.HttpStatusCode.NotFound" /> indicates that the requested resource does not exist on the server.</summary>
            NotFound = 404,
            /// <summary>Equivalent to HTTP status 405. <see cref="F:System.Net.HttpStatusCode.MethodNotAllowed" /> indicates that the request method (POST or GET) is not allowed on the requested resource.</summary>
            MethodNotAllowed = 405,
            /// <summary>Equivalent to HTTP status 406. <see cref="F:System.Net.HttpStatusCode.NotAcceptable" /> indicates that the client has indicated with Accept headers that it will not accept any of the available representations of the resource.</summary>
            NotAcceptable = 406,
            /// <summary>Equivalent to HTTP status 407. <see cref="F:System.Net.HttpStatusCode.ProxyAuthenticationRequired" /> indicates that the requested proxy requires authentication. The Proxy-authenticate header contains the details of how to perform the authentication.</summary>
            ProxyAuthenticationRequired = 407,
            /// <summary>Equivalent to HTTP status 408. <see cref="F:System.Net.HttpStatusCode.RequestTimeout" /> indicates that the client did not send a request within the time the server was expecting the request.</summary>
            RequestTimeout = 408,
            /// <summary>Equivalent to HTTP status 409. <see cref="F:System.Net.HttpStatusCode.Conflict" /> indicates that the request could not be carried out because of a conflict on the server.</summary>
            Conflict = 409,
            /// <summary>Equivalent to HTTP status 410. <see cref="F:System.Net.HttpStatusCode.Gone" /> indicates that the requested resource is no longer available.</summary>
            Gone = 410,
            /// <summary>Equivalent to HTTP status 411. <see cref="F:System.Net.HttpStatusCode.LengthRequired" /> indicates that the required Content-length header is missing.</summary>
            LengthRequired = 411,
            /// <summary>Equivalent to HTTP status 412. <see cref="F:System.Net.HttpStatusCode.PreconditionFailed" /> indicates that a condition set for this request failed, and the request cannot be carried out. Conditions are set with conditional request headers like If-Match, If-None-Match, or If-Unmodified-Since.</summary>
            PreconditionFailed = 412,
            /// <summary>Equivalent to HTTP status 413. <see cref="F:System.Net.HttpStatusCode.RequestEntityTooLarge" /> indicates that the request is too large for the server to process.</summary>
            RequestEntityTooLarge = 413,
            /// <summary>Equivalent to HTTP status 414. <see cref="F:System.Net.HttpStatusCode.RequestUriTooLong" /> indicates that the URI is too long.</summary>
            RequestUriTooLong = 414,
            /// <summary>Equivalent to HTTP status 415. <see cref="F:System.Net.HttpStatusCode.UnsupportedMediaType" /> indicates that the request is an unsupported type.</summary>
            UnsupportedMediaType = 415,
            /// <summary>Equivalent to HTTP status 416. <see cref="F:System.Net.HttpStatusCode.RequestedRangeNotSatisfiable" /> indicates that the range of data requested from the resource cannot be returned, either because the beginning of the range is before the beginning of the resource, or the end of the range is after the end of the resource.</summary>
            RequestedRangeNotSatisfiable = 416,
            /// <summary>Equivalent to HTTP status 417. <see cref="F:System.Net.HttpStatusCode.ExpectationFailed" /> indicates that an expectation given in an Expect header could not be met by the server.</summary>
            ExpectationFailed = 417,
            /// <summary>Equivalent to HTTP status 421. <see cref="F:System.Net.HttpStatusCode.MisdirectedRequest" /> indicates that the request was directed at a server that is not able to produce a response.</summary>
            MisdirectedRequest = 421,
            /// <summary>Equivalent to HTTP status 422. <see cref="F:System.Net.HttpStatusCode.UnprocessableEntity" /> indicates that the request was well-formed but was unable to be followed due to semantic errors.</summary>
            UnprocessableEntity = 422,
            /// <summary>Equivalent to HTTP status 423. <see cref="F:System.Net.HttpStatusCode.Locked" /> indicates that the source or destination resource is locked.</summary>
            Locked = 423,
            /// <summary>Equivalent to HTTP status 424. <see cref="F:System.Net.HttpStatusCode.FailedDependency" /> indicates that the method couldn't be performed on the resource because the requested action depended on another action and that action failed.</summary>
            FailedDependency = 424,
            /// <summary>Equivalent to HTTP status 426. <see cref="F:System.Net.HttpStatusCode.UpgradeRequired" /> indicates that the client should switch to a different protocol such as TLS/1.0.</summary>
            UpgradeRequired = 426,
            /// <summary>Equivalent to HTTP status 428. <see cref="F:System.Net.HttpStatusCode.PreconditionRequired" /> indicates that the server requires the request to be conditional.</summary>
            PreconditionRequired = 428,
            /// <summary>Equivalent to HTTP status 429. <see cref="F:System.Net.HttpStatusCode.TooManyRequests" /> indicates that the user has sent too many requests in a given amount of time.</summary>
            TooManyRequests = 429,
            /// <summary>Equivalent to HTTP status 431. <see cref="F:System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge" /> indicates that the server is unwilling to process the request because its header fields (either an individual header field or all the header fields collectively) are too large.</summary>
            RequestHeaderFieldsTooLarge = 431,
            /// <summary>Equivalent to HTTP status 451. <see cref="F:System.Net.HttpStatusCode.UnavailableForLegalReasons" /> indicates that the server is denying access to the resource as a consequence of a legal demand.</summary>
            UnavailableForLegalReasons = 451,
            /// <summary>Equivalent to HTTP status 500. <see cref="F:System.Net.HttpStatusCode.InternalServerError" /> indicates that a generic error has occurred on the server.</summary>
            InternalServerError = 500,
            /// <summary>Equivalent to HTTP status 501. <see cref="F:System.Net.HttpStatusCode.NotImplemented" /> indicates that the server does not support the requested function.</summary>
            NotImplemented = 501,
            /// <summary>Equivalent to HTTP status 502. <see cref="F:System.Net.HttpStatusCode.BadGateway" /> indicates that an intermediate proxy server received a bad response from another proxy or the origin server.</summary>
            BadGateway = 502,
            /// <summary>Equivalent to HTTP status 503. <see cref="F:System.Net.HttpStatusCode.ServiceUnavailable" /> indicates that the server is temporarily unavailable, usually due to high load or maintenance.</summary>
            ServiceUnavailable = 503,
            /// <summary>Equivalent to HTTP status 504. <see cref="F:System.Net.HttpStatusCode.GatewayTimeout" /> indicates that an intermediate proxy server timed out while waiting for a response from another proxy or the origin server.</summary>
            GatewayTimeout = 504,
            /// <summary>Equivalent to HTTP status 505. <see cref="F:System.Net.HttpStatusCode.HttpVersionNotSupported" /> indicates that the requested HTTP version is not supported by the server.</summary>
            HttpVersionNotSupported = 505,
            /// <summary>Equivalent to HTTP status 506. <see cref="F:System.Net.HttpStatusCode.VariantAlsoNegotiates" /> indicates that the chosen variant resource is configured to engage in transparent content negotiation itself and, therefore, isn't a proper endpoint in the negotiation process.</summary>
            VariantAlsoNegotiates = 506,
            /// <summary>Equivalent to HTTP status 507. <see cref="F:System.Net.HttpStatusCode.InsufficientStorage" /> indicates that the server is unable to store the representation needed to complete the request.</summary>
            InsufficientStorage = 507,
            /// <summary>Equivalent to HTTP status 508. <see cref="F:System.Net.HttpStatusCode.LoopDetected" /> indicates that the server terminated an operation because it encountered an infinite loop while processing a WebDAV request with "Depth: infinity". This status code is meant for backward compatibility with clients not aware of the 208 status code <see cref="F:System.Net.HttpStatusCode.AlreadyReported" /> appearing in multistatus response bodies.</summary>
            LoopDetected = 508,
            /// <summary>Equivalent to HTTP status 510. <see cref="F:System.Net.HttpStatusCode.NotExtended" /> indicates that further extensions to the request are required for the server to fulfill it.</summary>
            NotExtended = 510,
            /// <summary>Equivalent to HTTP status 511. <see cref="F:System.Net.HttpStatusCode.NetworkAuthenticationRequired" /> indicates that the client needs to authenticate to gain network access; it's intended for use by intercepting proxies used to control access to the network.</summary>
            NetworkAuthenticationRequired = 0x1FF,
            #endregion

            #region appuser database
            APPUSER_WRONG_PASSWORD_USERNAME = 100000,
            APPUSER_CANNOT_SAVE_TOKEN,
            APPUSER_CANNOT_GET_USER_FOR_REPORT,
            APPUSER_CANNOT_GET_OFFLINE_USER,
            APPUSER_CANNOT_GET_TOKEN_REQUEST,
            #endregion

            #region premier database
            PREMIERDB_DATA_IS_NULL = 200000,
            #endregion
        }

        public class PreServerResponseData
        {
            public PRE_SERVER_RETURN_CODE Code { get; set; }
            public Object Data { get; set; }

            public PreServerResponseData()
            {
                this.Code = PRE_SERVER_RETURN_CODE.FAIL;
                this.Data = "";
            }
        }

        public enum PREMIER_DUCTS_SERVER_API_TYPE
        {
            #region [COMMON]
            LOGIN = 0,
            #endregion

            #region [APP_USER]
            APP_USER_GET_ONLINE_USER,
            APP_USER_GET_OFFLINE_USER,
            #endregion

            #region [PREMIER_DUCTS]
            PREMIER_DUCTS_GET_ALL_JOBTIMING,
            PREMIER_DUCTS_GET_ALL_JOBTIMING_DETAIL_BY_DATE,
            PREMIER_DUCTS_GET_STATION_DATA,
            PREMIER_DUCTS_GET_ALL_JOBTIMING_DATES,
            PREMIER_DUCTS_GET_ALL_DURATION_STATION,
            #endregion

            #region [QLD_DATA]
            QLD_GET_ALL,
            QLD_TOTAL_ALL_M2,
            #endregion

            #region [DELIVERY]
            GET_ORDER,
            CREATE_ORDER,
            DELETE_ORDER,
            UPDATE_ORDER,
            GET_ALL_CAGES,
            GET_ALL_ITEM,
            #endregion

        }

        public class PremierDuctsServerApiBase
        {
            public static Dictionary<PREMIER_DUCTS_SERVER_API_TYPE, String> HttpCommands = new Dictionary<PREMIER_DUCTS_SERVER_API_TYPE, String>()
            {
                #region [COMMON]
                {PREMIER_DUCTS_SERVER_API_TYPE.LOGIN, "" },
                #endregion

                #region [APP_USER]
               
                {PREMIER_DUCTS_SERVER_API_TYPE.APP_USER_GET_OFFLINE_USER, "user/getOfflineUsers" },
                {PREMIER_DUCTS_SERVER_API_TYPE.APP_USER_GET_ONLINE_USER, "user/getOnlineUsers" },
                #endregion

                #region [PREMIER_DUCTS]
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_JOBTIMING, "jobtiming/data/detail" },
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_JOBTIMING_DETAIL_BY_DATE, "jobtiming/all/data/by_date"},

                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_STATION_DATA, "station/all"},
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_JOBTIMING_DATES, "jobtiming/list/dates" },
                {PREMIER_DUCTS_SERVER_API_TYPE.PREMIER_DUCTS_GET_ALL_DURATION_STATION, "station/all/duration" },

                #endregion

                #region [QLD_DATA]
                {PREMIER_DUCTS_SERVER_API_TYPE.QLD_GET_ALL, "dashboard/get/all/qldata"},
                {PREMIER_DUCTS_SERVER_API_TYPE.QLD_TOTAL_ALL_M2, "dashboard/total/all/m2"},
                #endregion

                #region [DELIVERY]
                {PREMIER_DUCTS_SERVER_API_TYPE.GET_ORDER, "api/Order/list"},
                {PREMIER_DUCTS_SERVER_API_TYPE.CREATE_ORDER, "api/Order/create"},
                {PREMIER_DUCTS_SERVER_API_TYPE.UPDATE_ORDER, "api/Order"},
                {PREMIER_DUCTS_SERVER_API_TYPE.DELETE_ORDER, "api/Order"},
                {PREMIER_DUCTS_SERVER_API_TYPE.GET_ALL_CAGES, "cages/all"},
                {PREMIER_DUCTS_SERVER_API_TYPE.GET_ALL_ITEM, "cage/items/all"},
                #endregion
            };
        }
    }
}
