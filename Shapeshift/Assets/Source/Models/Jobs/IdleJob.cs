using System;

namespace Shapeshift.Source.Models.Jobs {

	public class IdleJob : Job, IJob {

		public IdleJob() {
			WorkRequired = 0;
		}
	}
}

