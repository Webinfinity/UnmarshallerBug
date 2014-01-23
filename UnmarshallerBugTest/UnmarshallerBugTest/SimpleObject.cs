using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnmarshallerBugTest
{
	public class SimpleObjectFromAPIWithNewSubObjectsProperty
	{
		public string Property1 { get; set; }

		public List<SubObject> SubObjects1 { get; set; }

		public string Property2 { get; set; }

		public class SubObject
		{
			public string SubObjectProperty1 { get; set; }
		}
	}

	public class SimpleObjectInSDKWithoutSupportForNewSubObjectsProperty
	{
		public string Property1 { get; set; }
		
		public string Property2 { get; set; }
	}

	public class SimpleObjectInSDKWithSupportForNewSubObjectsProperty
	{
		public string Property1 { get; set; }

		public string Property2 { get; set; }

		public List<SubObject> SubObjects1 { get; set; }

		public class SubObject
		{
			public string SubObjectProperty1 { get; set; }
		}
	}
}
