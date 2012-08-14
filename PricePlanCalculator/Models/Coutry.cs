namespace PricePlanCalculator.Models
{
	public class Coutry
	{
		private string Name { get; set; }

		public Coutry(string name)
		{
			Name = name;
		}

		public bool Equals(Coutry other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Name, Name);
		}
	}
}