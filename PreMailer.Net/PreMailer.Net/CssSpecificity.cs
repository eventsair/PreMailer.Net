﻿namespace PreMailer.Net
{
	public class CssSpecificity
	{
		public int Ids { get; protected set; }

		/// <summary>
		/// Classes, attributes and pseudo-classes.
		/// </summary>
		public int Classes { get; protected set; }

		/// <summary>
		/// Elements and pseudo-elements.
		/// </summary>
		public int Elements { get; protected set; }

		public static CssSpecificity None => new CssSpecificity(0, 0, 0);

		public CssSpecificity(int ids, int classes, int elements)
		{
			Ids = ids;
			Classes = classes;
			Elements = elements;
		}

		public int ToInt()
		{
			var s = ToString();
			var success = int.TryParse(s, out var result);
			return result;
		}

		public override string ToString()
		{
			return $"{Ids}{Classes}{Elements}";
		}

		public static CssSpecificity operator +(CssSpecificity first, CssSpecificity second)
		{
			return new CssSpecificity(
				first.Ids + second.Ids,
				first.Classes + second.Classes,
				first.Elements + second.Elements);
		}
	}
}