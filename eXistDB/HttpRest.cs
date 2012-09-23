/*
 *  eXist Open Source Native XML Database
 *  Copyright (C) 2012 The eXist Project
 *  http://exist-db.org
 *
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public License
 *  as published by the Free Software Foundation; either version 2
 *  of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 *
 *  $Id$
 */
using System;
using System.Net;
using System.Text;
using System.IO;

namespace org.exist.dotNet
{
	public class HttpRest
	{
		public enum Method
		{
			Delete,
			Get,
			Post,
			Put
		}
		
		private static HttpStatusCode request(Uri uri, Method method, string body)
		{

			var w = (HttpWebRequest)WebRequest.Create(uri);
			w.Proxy = null;
			w.Method = method.ToString();
			w.ContentType = "application/json";

			if (!string.IsNullOrEmpty(body))
			{
				var dataStream = w.GetRequestStream();

				byte[] b = Encoding.UTF8.GetBytes(body);
				dataStream.Write(b, 0, b.Length);
				dataStream.Close();
			}

			HttpStatusCode statusCode;
			try
			{
				var resp = w.GetResponse();

				resp.Close();

				statusCode = ((HttpWebResponse) resp).StatusCode;
			}
			catch (WebException ex)
			{
				var webResponse = ex.Response;

				webResponse.Close();

				statusCode = ((HttpWebResponse)webResponse).StatusCode;
			}

			return statusCode;
		}

		private static HttpStatusCode requestStream(Uri uri, Method method, string body, out Stream response)
        {

			var w = (HttpWebRequest)WebRequest.Create(uri);
			w.Proxy = null;
			w.Method = method.ToString();
			w.ContentType = "application/json";
			w.Accept = "application/json";

			if (!string.IsNullOrEmpty(body))
			{
				Stream dataStream = w.GetRequestStream();

				byte[] b = Encoding.UTF8.GetBytes(body);
				dataStream.Write(b, 0, b.Length);
				dataStream.Close();
			}

			HttpStatusCode statusCode;
			try
			{
				var resp = w.GetResponse();

				response = resp.GetResponseStream();

				statusCode = ((HttpWebResponse) resp).StatusCode;
			}
			catch (WebException ex)
			{

				var webResponse = ex.Response;

				response = webResponse.GetResponseStream();

				statusCode = ((HttpWebResponse)webResponse).StatusCode;
			}

			return statusCode;
        }

		private static HttpStatusCode requestString(Uri uri, Method method, string body, out string response)
        {

			HttpStatusCode statusCode;
			Stream stream;

			statusCode = requestStream(uri, method, body, out stream);

			var reader = new StreamReader(stream);

			response = reader.ReadToEnd();

			reader.Close();

			return statusCode;
        }

		public static HttpStatusCode Get(Uri uri, out string response)
        {
            return requestString(uri, Method.Get, null, out response);
        }

     	public static HttpStatusCode Post(Uri uri, string body, out string response)
        {
            return requestString(uri, Method.Post, body, out response);
        }

		public static HttpStatusCode Put(Uri uri, string body)
        {
            return request(uri, Method.Put, body);
        }

		public static HttpStatusCode Delete(Uri uri)
        {
            return request(uri, Method.Delete, null);
        }
	}
}

