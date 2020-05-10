using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA_byBuka.Models
{
    public class Problem
    {
		public int id { get; set; }
        public string problem { get; set; }
		public Int16 isPublic { get; set; }
		public Int16 canAddAnswersEverybody { get; set; }
		public DateTime deadline { get; set; }
		public string reference { get; set; }
		public Int16 active { get; set; }
		public DateTime creationDate { get; set; }
		public int maxCountOfAnswers { get; set; }
	}
}
