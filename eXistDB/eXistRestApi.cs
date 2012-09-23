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
using System.IO;
using System.Net;
using System.Web;

namespace org.exist.dotNet
{
	public class eXistRestApi : Database
	{
		private eXistRestApi (Uri dbUri)
		{
		}
		
		public static Database connect(Uri dbUri)
		{
			string response;
			var status = HttpRest.Get(dbUri, out response);
			if (status != HttpStatusCode.OK)
			{
				throw new Exception(string.Format("Error getting database version (http response:{0})", status));
			}

			//TODO: check version
			Console.Write(response);

			return new eXistRestApi(dbUri);
		}
		
		//collections method
		public void createCollection(DBURI uri)
		{
		}
		
		//store document by stream
		public void storeDocument(DBURI uri, Stream stream)
		{
		}
		
		//get XML document
		//XMLDocument getXMLdocument(XmldbURI uri);

		//get Binary document
		//BinaryDocument getBinaryDocument(XmldbURI uri);

		//Common methods
		public void copy(DBURI fromURI, DBURI toURI)
		{
		}

		public void move(DBURI fromURI, DBURI toURI)
		{
		}

		public void delete(DBURI uri)
		{
		}
	}
}

