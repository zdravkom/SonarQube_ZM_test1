using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Zadatak_20221124
{
    public class Obrada
    {
        public Obrada()
        { }
        public Obrada()
        { }
        /// <summary>
        /// Obrada s dupliciranim parovima (npr.: 4+6 i 6+4 su dva različita para)
        /// </summary>
        /// <param name="prag"></param>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public static double IzracunajOptimiziranVer_1(int prag, int[] arr1, int[] arr2,  int n, int m)
        {
            Double elapsedMillisecs = 0d;

            Console.WriteLine("----->: Početak obrade IzracunajOptimiziranVer_1()...");
            Console.WriteLine("Prag: " + prag);

            IspisElemenataNiza("Arr1:", arr1);
            IspisElemenataNiza("Arr2:", arr2);

            DateTime startTime, endTime;
            startTime = DateTime.Now;

            Dictionary<int, int> myDict01 = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                myDict01[arr1[i]] = 0;
            }

            int key = 0;
            Dictionary<int, string> myDict02 = new Dictionary<int, string>();
            int k = 0;

            for (int j = 0; j < m; j++)
            {
                key = prag - arr2[j];
                if (myDict01.ContainsKey(key))
                    myDict02[j] = key + "+" + arr2[j];
            }
            var lapsedTime = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            endTime = DateTime.Now;
            elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;

            Console.Write("---- REZULTAT OBRADE ----");
            Console.Write("Start: " + startTime.ToString("hh:mm:ss.fff tt"));
            Console.Write("Kraj: " + endTime.ToString("hh:mm:ss.fff tt"));
            Console.WriteLine("Trajanje: " + lapsedTime + " msec; " + elapsedMillisecs + " msec");
            
            foreach (var value in myDict02)
                Console.WriteLine(value.Value);

            Console.WriteLine("-->: Kraj obrade!");

            return elapsedMillisecs;
        }
        /// <summary>
        /// Obrada u kojoj nema dupliciranih parova  (npr.: 4+6 i 6+4 je jedan par)
        /// </summary>
        /// <param name="prag"></param>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public static Double IzracunajOptimiziranVer_2(int prag, int[] arr1, int[] arr2, int n, int m)
        {
            Double elapsedMillisecs=0.0d;

            Console.WriteLine("----->: Početak obrade IzracunajOptimiziranVer_2()...");
            Console.WriteLine("Prag: " + prag);

            IspisElemenataNiza("Arr1:", arr1);
            IspisElemenataNiza("Arr2:", arr2);

            DateTime startTime, endTime;
            startTime = DateTime.Now;

            Dictionary<int, int> myDict01 = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                myDict01[arr1[i]] = 0;
            }

            int key = 0;
            string tmp_key = String.Empty;
            Dictionary<int, string> myDict02 = new Dictionary<int, string>();

            for (int j = 0; j < m; j++)
            {
                key = prag - arr2[j];
                if (myDict01.ContainsKey(key))
                {
                    tmp_key = key + "+" + arr2[j];
                    if (!myDict02.ContainsValue(tmp_key))
                        myDict02[j] = tmp_key;
                }
            }
            var lapsedTime = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            endTime = DateTime.Now;
            elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;

            Console.Write("---- REZULTAT OBRADE ----");
            Console.Write("Start: " + startTime.ToString("hh:mm:ss.fff tt"));
            Console.Write("Kraj: " + endTime.ToString("hh:mm:ss.fff tt"));
            Console.WriteLine("Trajanje: " + lapsedTime + " msec; " + elapsedMillisecs + " msec");

            foreach (var value in myDict02)
                Console.WriteLine(value.Value);
            Console.WriteLine("-->: Kraj obrade!");

            return elapsedMillisecs;
        }

        /// <summary>
        /// Obrada u kojoj se traži točna vrijednost sume definirana varijablom "prag"
        /// </summary>
        /// <param name="prag"></param>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="sort_arr1"></param>
        /// <param name="sort_arr2"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Double IzracunajBezTolerancije(int prag, int[] arr1, int[] arr2, bool sort_arr1, bool sort_arr2, bool info)
        {
            Double elapsedMillisecs=0.0d;

            Console.WriteLine("----->: Početak obrade IzracunajBezTolerancije()...");
            Console.WriteLine("Prag: " + prag);

            string zarez = ",";

            string tmp_str = String.Empty;

            if (sort_arr1) Array.Sort(arr1);

            IspisElemenataNiza("Arr1:", arr1);

            if (sort_arr2) Array.Sort(arr2);

            IspisElemenataNiza("Arr2:", arr2);

            DateTime startTime, endTime;
            startTime = DateTime.Now;

            int div_abs_int = 0;
            int sum_arr1_arr2 = 0;

            Dictionary<string, int> myDict1 = new Dictionary<string, int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    sum_arr1_arr2 = arr1[i] + arr2[j];
                    div_abs_int = Math.Abs(prag - sum_arr1_arr2);

                    if(info)
                    { 
                        Console.Write("[i=" + i + zarez + "j=" + j + "] " + arr1[i].ToString("0#") + " + " + arr2[j].ToString("0#") + " = " + sum_arr1_arr2.ToString("0#"));
                        Console.WriteLine("\t\tAbs(" + prag.ToString("0#") + "-" + sum_arr1_arr2.ToString("0#") + ") = " + div_abs_int.ToString("0#"));
                    }
                    try
                    {
                        tmp_str = arr1[i].ToString() + "," + arr2[j].ToString();
                        if (!myDict1.ContainsKey(tmp_str))
                            myDict1.Add(tmp_str, div_abs_int);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("--> Problem: "+ex.Message + " ----");
                    }

                }
            }
            var ordered = myDict1.OrderBy(x => x.Value)
                                .ToDictionary(x => x.Key, x => x.Value)
                                .Where(e => e.Value == myDict1.Min(e2 => e2.Value));

            var lapsedTime = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            endTime = DateTime.Now;
            elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;

            Console.Write("---- REZULTAT OBRADE ----");
            Console.Write("Start: " + startTime.ToString("hh:mm:ss.fff tt"));
            Console.Write("Kraj: " + endTime.ToString("hh:mm:ss.fff tt"));
            Console.WriteLine("Trajanje: " + lapsedTime + " msec; " + elapsedMillisecs + " msec");

            foreach (var value in ordered)
            {
                Console.WriteLine(value.Key.Replace(',', '+'));
            }

            Console.WriteLine("-->: Kraj obrade!");
            return elapsedMillisecs;
        }

        /// <summary>
        /// Obrada u kojoj se traže sve vrijednosti koje odstupaju od definirane vrijednosti (varijablom "prag"). 
        /// Tolerancija je definirana varijablom "tolerancija".
        /// </summary>
        /// <param name="prag"></param>
        /// <param name="tolerancija"></param>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="sort_arr1"></param>
        /// <param name="sort_arr2"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Double IzracunajUzToleranciju(int prag, int tolerancija, int[] arr1, int[] arr2, bool sort_arr1, bool sort_arr2, bool info)
        {
            Double elapsedMillisecs=0.0d;

            Console.WriteLine("----->: Početak obrade IzracunajUzToleranciju()...");
            Console.WriteLine("Prag: " + prag);
            Console.WriteLine("Tolerancija: " + tolerancija);
            string zarez = ",";

            string tmp_str = String.Empty;

            if (sort_arr1) Array.Sort(arr1);

            IspisElemenataNiza("Arr1:", arr1);

            if (sort_arr2) Array.Sort(arr2);

            IspisElemenataNiza("Arr2:", arr2);

            int div_abs_int = 0;
            int sum_arr1_arr2 = 0;

            DateTime startTime, endTime;
            startTime = DateTime.Now;

            Dictionary<string, int> myDict1 = new Dictionary<string, int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    sum_arr1_arr2 = arr1[i] + arr2[j];
                    div_abs_int = Math.Abs(prag - sum_arr1_arr2);

                    if (info)
                    {
                        Console.Write("[i=" + i + zarez + "j=" + j + "] " + arr1[i].ToString("0#") + " + " + arr2[j].ToString("0#") + " = " + sum_arr1_arr2.ToString("0#"));
                        Console.WriteLine("\t\tAbs(" + prag.ToString("0#") + "-" + sum_arr1_arr2.ToString("0#") + ") = " + div_abs_int.ToString("0#"));
                    }
                    try
                    {
                        tmp_str = arr1[i].ToString() + "," + arr2[j].ToString();
                        if (!myDict1.ContainsKey(tmp_str))
                            myDict1.Add(tmp_str, div_abs_int);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("--> Problem: " + ex.Message + " ----");
                    }

                }
            }
            var ordered = myDict1.OrderBy(x => x.Value)
                                .ToDictionary(x => x.Key, x => x.Value);

            var lapsedTime = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            endTime = DateTime.Now;
            elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;

            Console.Write("---- REZULTAT OBRADE ----");
            Console.Write("Start: " + startTime.ToString("hh:mm:ss.fff tt"));
            Console.Write("Kraj: " + endTime.ToString("hh:mm:ss.fff tt"));
            Console.WriteLine("Trajanje: " + lapsedTime + " msec; " + elapsedMillisecs + " msec");

            for (int i = 0; i <= tolerancija; i++)
            {
                var ordered2 = ordered.Where(e => e.Value == ordered.Min(e2 => (e2.Value + i)));
                foreach (var value in ordered2)
                {
                    Console.WriteLine(value.Key.Replace(',', '+'));
                }
            }


            Console.WriteLine("-->: Kraj obrade!");
            return elapsedMillisecs;
        }

        /// <summary>
        /// Ispis ulaznih podataka.
        /// </summary>
        /// <param name="naslov"></param>
        /// <param name="arr"></param>
        private static void IspisElemenataNiza(string naslov, int[] arr)
        {
            Console.Write(naslov);
            string zarez = ",";
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    Console.Write(" [");
                if (i < arr.Length - 1)
                    Console.Write(arr[i] + zarez);
                else
                    Console.WriteLine(arr[i] + "]");
            }
        }

        internal static int[] KreirajNiz(int min, int max, int loopnum)
        {
            int[] arr = new int[loopnum];
            System.Random random = new System.Random();
            for (int i = 0; i < loopnum; i++)
                arr[i] = random.Next(min, max);

            return arr;
        }
    }
}
