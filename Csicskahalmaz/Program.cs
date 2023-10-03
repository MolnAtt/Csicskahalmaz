using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Csicskahalmaz
{
	internal class Program
	{

		class CsicskaHalmaz
		{
			private List<int> lista;
			//public int Count() => lista.Count;
			public int Count 
			{
				get
				{
					return lista.Count;
				}
			}
			// public int Count { get => lista.Count; }

			public CsicskaHalmaz() 
			{ 
				lista = new List<int>();
			}

			public bool Benne_van(int elem)
			{
				int i = 0;
				while (i<lista.Count && !(elem == lista[i]))
				{
					i++;
				}
				return i<lista.Count;
			}

			public void Add(int elem)
			{
				if (!Benne_van(elem))
				{
					lista.Add(elem); 
				}
			} 

			public void Remove(int elem)
			{
				lista.Remove(elem);
			}

			public static CsicskaHalmaz operator +(CsicskaHalmaz a, CsicskaHalmaz b)
			{
				CsicskaHalmaz result = new CsicskaHalmaz(); // 1
				result.lista = new List<int>(a.lista); // n
				foreach (int belem in b.lista) // m 
				{
					result.Add(belem); // n
				} // m*n
				return result;
			} // valójában ennek az ideje 1+n+m*n --> ez nagyon lassú. 
			// ha pont ugyanakkora lenne a két halmaz, akkor n=m, akkor ennek az ideje n^2+n+1 --> valójában ez egy n^2 nagyságrendű rendezés.


			public static CsicskaHalmaz operator *(CsicskaHalmaz a, CsicskaHalmaz b)
			{
				CsicskaHalmaz result = new CsicskaHalmaz(); // 1
				foreach (int belem in b.lista) // m 
				{
					if (a.Benne_van(belem)) // n
					{
						result.lista.Add(belem); // 1
					}
				}
				return result;
			} // 1+m*(n+1)  -- y m*n tehát n^2-es polinomiális idő. 

			/// <summary>
			/// azon elemei a-nek, amelyek nem szerepelnek b-ben.
			/// </summary>
			/// <param name="a"></param>
			/// <param name="b"></param>
			/// <returns></returns>
			public static CsicskaHalmaz operator -(CsicskaHalmaz a, CsicskaHalmaz b)
			{
				CsicskaHalmaz result = new CsicskaHalmaz();
				foreach (int aelem in a.lista)
				{
					if (!b.Benne_van(aelem))
					{
						result.lista.Add(aelem);
					}
				}
				return result;
			}


			public override string ToString()
			{
				string result = "{ ";
				for (int i = 0; i < lista.Count-1; i++)
				{
					result += lista[i].ToString() + "; ";
				}

				if (0 < lista.Count)
				{
					result += lista[lista.Count - 1].ToString();
				}

				return result += " }";
			}



		}
		static void Main(string[] args)
		{
			CsicskaHalmaz halmaz = new CsicskaHalmaz();

			halmaz.Add(5);
			halmaz.Add(2);
			halmaz.Add(3);
			Console.WriteLine(halmaz);

			CsicskaHalmaz halmaz2 = new CsicskaHalmaz();
			halmaz2.Add(5);
			halmaz2.Add(2);
			halmaz2.Add(7);
			halmaz2.Add(8);

			Console.WriteLine(halmaz2);
			Console.WriteLine(halmaz + halmaz2);// unió
			Console.WriteLine(halmaz * halmaz2);// metszet
			Console.WriteLine(halmaz);
			Console.WriteLine(halmaz2);
            Console.WriteLine(halmaz.Count);

        }
	}
}
