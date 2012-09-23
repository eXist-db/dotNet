using System;
using NUnit.Framework;
using org.exist.dotNet;

namespace test
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void storeXMLdocument ()
		{
			Database db = eXistRestApi.connect(new Uri("http://exist-db.org/exist"));
			Assert.IsNotNull(db);
		}
	}
}

