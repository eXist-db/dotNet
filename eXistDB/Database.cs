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

namespace org.exist.dotNet
{
	public interface Database
	{

		//collections method
		void createCollection(DBURI uri);
		
		//store document by stream
		void storeDocument(DBURI uri, Stream stream);
		
		//get XML document
		//XMLDocument getXMLdocument(XmldbURI uri);

		//get Binary document
		//BinaryDocument getBinaryDocument(XmldbURI uri);

		//Common methods
		void copy(DBURI fromURI, DBURI toURI);

		void move(DBURI fromURI, DBURI toURI);

		void delete(DBURI uri);
	}
}
