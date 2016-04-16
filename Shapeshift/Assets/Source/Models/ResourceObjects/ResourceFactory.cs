using System;

namespace Shapeshift.Source.Models.ResourceObjects {
	
	public class ResourceFactory {

		public Resource CreateResource(ResourceType type) {

			Resource resource = null;

			// Commented out for now 
			/*
			switch (type) {
				case ResourceType.Wood:
					resource = new WoodResource();
						break;
			}
			*/
			return resource;
		}
	}
}

