using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;

namespace UnmarshallerBugTest
{
	public class SimpleUnmarshallerWithoutSupportForNewSubObjectsProperty : JsonResponseUnmarshaller
	{
		public SimpleObjectInSDKWithoutSupportForNewSubObjectsProperty Unmarshall(JsonUnmarshallerContext context)
        {
			SimpleObjectInSDKWithoutSupportForNewSubObjectsProperty response = new SimpleObjectInSDKWithoutSupportForNewSubObjectsProperty();          
          
			context.Read();
          
			UnmarshallResult(context,response);
			return response;
        }

		private static void UnmarshallResult(JsonUnmarshallerContext context, SimpleObjectInSDKWithoutSupportForNewSubObjectsProperty response)
		{
			int originalDepth = context.CurrentDepth;
			int targetDepth = originalDepth + 1;

			while (context.Read())
			{
				if (context.TestExpression("Property1", targetDepth))
				{
					context.Read();
					response.Property1 = StringUnmarshaller.GetInstance().Unmarshall(context);
					continue;
				}

				if (context.TestExpression("Property2", targetDepth))
				{
					context.Read();
					response.Property2 = StringUnmarshaller.GetInstance().Unmarshall(context);
					continue;
				}
				
				if (context.CurrentDepth <= originalDepth)
				{
					return;
				}
			}

			return;
		}              
	}

	public class SimpleUnmarshallerWithSupportForNewSubObjectsProperty : JsonResponseUnmarshaller
	{
		public SimpleObjectInSDKWithSupportForNewSubObjectsProperty Unmarshall(JsonUnmarshallerContext context)
		{
			SimpleObjectInSDKWithSupportForNewSubObjectsProperty response = new SimpleObjectInSDKWithSupportForNewSubObjectsProperty();

			context.Read();

			UnmarshallResult(context, response);
			return response;
		}

		private static void UnmarshallResult(JsonUnmarshallerContext context, SimpleObjectInSDKWithSupportForNewSubObjectsProperty response)
		{
			int originalDepth = context.CurrentDepth;
			int targetDepth = originalDepth + 1;

			while (context.Read())
			{
				if (context.TestExpression("Property1", targetDepth))
				{
					context.Read();
					response.Property1 = StringUnmarshaller.GetInstance().Unmarshall(context);
					continue;
				}

				if (context.TestExpression("Property2", targetDepth))
				{
					context.Read();
					response.Property2 = StringUnmarshaller.GetInstance().Unmarshall(context);
					continue;
				}
				
				if (context.TestExpression("SubObjects1", targetDepth))
				{
					context.Read();
					response.SubObjects1 = new List<SimpleObjectInSDKWithSupportForNewSubObjectsProperty.SubObject>();

					SimpleSubObjectUnmarshaller unmarshaller = new SimpleSubObjectUnmarshaller();
					while (context.Read())
					{
						JsonToken token = context.CurrentTokenType;
						if (token == JsonToken.ArrayStart)
						{
							continue;
						}
						if (token == JsonToken.ArrayEnd)
						{
							break;
						}
						response.SubObjects1.Add(unmarshaller.Unmarshall(context));
					}
					continue;
				}
				
				if (context.CurrentDepth <= originalDepth)
				{
					return;
				}
			}

			return;
		}

		public class SimpleSubObjectUnmarshaller : JsonResponseUnmarshaller
		{
			public SimpleObjectInSDKWithSupportForNewSubObjectsProperty.SubObject Unmarshall(JsonUnmarshallerContext context)
			{
				SimpleObjectInSDKWithSupportForNewSubObjectsProperty.SubObject response = new SimpleObjectInSDKWithSupportForNewSubObjectsProperty.SubObject();

				UnmarshallResult(context, response);
				return response;
			}

			private static void UnmarshallResult(JsonUnmarshallerContext context, SimpleObjectInSDKWithSupportForNewSubObjectsProperty.SubObject response)
			{
				int originalDepth = context.CurrentDepth;
				int targetDepth = originalDepth + 1;

				while (context.Read())
				{
					if (context.TestExpression("SubObjectProperty1", targetDepth))
					{
						context.Read();
						response.SubObjectProperty1 = StringUnmarshaller.GetInstance().Unmarshall(context);
						continue;
					}

					if (context.CurrentDepth <= originalDepth)
					{
						return;
					}
				}

				return;
			}
		}
	}
}
