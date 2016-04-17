using System;

namespace Shapeshift.Source.Models.Resources {
	
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

