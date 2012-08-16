namespace PricePlanCalculator.Models
{
	public class Coutry
	{
		private string Name { get; set; }

		private Coutry(string name)
		{
			Name = name;
		}

		public bool Equals(Coutry other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Name, Name);
		}

		public static readonly Coutry Denmark = new Coutry("Denmark");
		public static readonly Coutry Uk = new Coutry("UK");
	}
}