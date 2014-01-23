using Amazon.DynamoDBv2.Model;
using Amazon.Runtime.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace UnmarshallerBugTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var ser = new JavaScriptSerializer();

			// This string represents the JSON response from the API that includes a new property (SubObjects1) which is a list of objects
			var json = ser.Serialize(new SimpleObjectFromAPIWithNewSubObjectsProperty
			{
				Property1 = "Prop1Val",
				Property2 = "Prop2Val",
				SubObjects1 = new List<SimpleObjectFromAPIWithNewSubObjectsProperty.SubObject>
				{
					new SimpleObjectFromAPIWithNewSubObjectsProperty.SubObject
					{
						SubObjectProperty1 = "SubObjectProp1Val" 
					}
				}
			});
			
			// withoutSupport is the unmarshalled object for the returned JSON object if the SDK does not yet support the new property
			var withoutSupport = new SimpleUnmarshallerWithoutSupportForNewSubObjectsProperty().Unmarshall(new Amazon.Runtime.Internal.Transform.JsonUnmarshallerContext(json, null)) as SimpleObjectInSDKWithoutSupportForNewSubObjectsProperty;

			// withSupport is the unmarshalled object for the returned JSON object if the SDK does support the new property
			var withSupport = new SimpleUnmarshallerWithSupportForNewSubObjectsProperty().Unmarshall(new Amazon.Runtime.Internal.Transform.JsonUnmarshallerContext(json, null)) as SimpleObjectInSDKWithSupportForNewSubObjectsProperty;

			if (withoutSupport.Property2 != withSupport.Property2)
				Console.WriteLine("Property2 does not match!");
			else
				Console.WriteLine("All good");

			Console.ReadLine();
		}
	}
}
