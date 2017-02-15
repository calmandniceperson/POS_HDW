using System;
namespace CSHashTree
{
	public class Student
	{
		public int PK { get; private set; }
		public string Klasse { get; private set; }
		public int KatalogNummer { get; private set; }
		public string Name { get; private set; }
		public string Vorname { get; private set; }

		public Student(int pk, string klasse, int kn, string name, string vorname)
		{
			PK = pk;
			Klasse = klasse;
			KatalogNummer = kn;
			Name = name;
			Vorname = vorname;
		}

		public override string ToString()
		{
			return string.Format("[Student: PK={0}, Klasse={1}, KatalogNummer={2}, Name={3}, Vorname={4}]", PK, Klasse, KatalogNummer, Name, Vorname);
		}
	}
}
