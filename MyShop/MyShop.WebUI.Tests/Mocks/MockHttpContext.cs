using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockHttpContext : HttpContextBase
    {
        private MockRequest request;
        private MockResponse response;
        private HttpCookieCollection cookies;

        public MockHttpContext()
        {
            cookies = new HttpCookieCollection();
            this.request = new MockRequest(cookies);
            this.response = new MockResponse(cookies);
        }

        //---Not working, find out WHY?
        //public override HttpRequestBase Request
        //{
        //    get
        //    {
        //        //---No
        //        //return request;
        //    }
        //}

        public override HttpResponseBase Response
        {
            get
            {
                return response;
            }
        }
    }

    //---Returning old cookies
    public class MockResponse : HttpResponseBase
    {
        //---overriding methods
        private readonly HttpCookieCollection cookies;

        //---Constructor
        public MockResponse(HttpCookieCollection cookies)
        {
            this.cookies = cookies;

        }

        //---Override base method of HttpCookieCollection
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }

        }
    }

    //---Returning old cookies
    public class MockRequest : HttpResponseBase
    {
        //---overriding methods
        private readonly HttpCookieCollection cookies;

        //---Constructor
        public MockRequest(HttpCookieCollection cookies)
        {
            this.cookies = cookies;

        }

        //---Override base method of HttpCookieCollection
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }

        }
    }
}
