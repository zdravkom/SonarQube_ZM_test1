using ConsoleApp1_Zadatak_20221124;

int prag = 11;
int tolerancija = 2;

//test 1.
//int[] arr1 = { 1, 7, 4, 10, 7, 4, 7};
//int[] arr2 = { 5, 3, 6, 9, 9, 1, 0 , 1};

//test 2.
//int[] arr1 = { 1, 7, 4, 6, 11, 6, 7, 4, 7 };
//int[] arr2 = { 5, 3, 6, 9, 9 };

//test 3.
//int[] arr1 = { 1, 7, 4, 6, 11, 4, 11, 6, 4, 11 };
//int[] arr2 = { 5, 3, 6, 9, 4, 3, 6, 4, 9};


int broj_testova = 12;
int broj_ponavljanja = 20;
Double[] prosj_vrijeme_testova = new Double[broj_ponavljanja];
Double prosjek_testa = 0.0d;

for (int i=0; i< broj_ponavljanja; i++)
{ 
    int[] arr1 = Obrada.KreirajNiz(0, 10, 50);
    int[] arr2 = Obrada.KreirajNiz(0, 10, 50);

    Double[] vrijeme_obrade = new Double[12];

    int k = 0;
    //Obrada s dupliciranim parovima (npr.: 4+6 i 6+4 su dva različita para)
    vrijeme_obrade[k]= Obrada.IzracunajOptimiziranVer_1(prag - 2, arr1, arr2, arr1.Length, arr2.Length);

    vrijeme_obrade[++k] = Obrada.IzracunajOptimiziranVer_1(prag - 1, arr1, arr2, arr1.Length, arr2.Length);

    vrijeme_obrade[++k] = Obrada.IzracunajOptimiziranVer_1(prag, arr1, arr2, arr1.Length, arr2.Length);

    //Obrada u kojoj nema dupliciranih parova  (npr.: 4+6 i 6+4 je jedan par)
    vrijeme_obrade[++k] = Obrada.IzracunajOptimiziranVer_2(prag - 2, arr1, arr2, arr1.Length, arr2.Length);

    vrijeme_obrade[++k] = Obrada.IzracunajOptimiziranVer_2(prag - 1, arr1, arr2, arr1.Length, arr2.Length);

    vrijeme_obrade[++k] = Obrada.IzracunajOptimiziranVer_2(prag, arr1, arr2, arr1.Length, arr2.Length);

    //Obrada u kojoj se traži točna vrijednost sume definirana varijablom "prag"
    vrijeme_obrade[++k] = Obrada.IzracunajBezTolerancije(prag - 2 , arr1, arr2, false, false, false);

    vrijeme_obrade[++k] = Obrada.IzracunajBezTolerancije(prag - 1, arr1, arr2, false, false, false);

    vrijeme_obrade[++k] = Obrada.IzracunajBezTolerancije(prag, arr1, arr2, false, false, false);

    //Obrada u kojoj se traže sve vrijednosti koje odstupaju od definirane vrijednosti (varijablom "prag"). Tolerancija je definirana varijablom "tolerancija".

    vrijeme_obrade[++k] = Obrada.IzracunajUzToleranciju(prag - 2, tolerancija, arr1, arr2, false, false, false);

    vrijeme_obrade[++k] = Obrada.IzracunajUzToleranciju(prag - 1, tolerancija, arr1, arr2, false, false, false);

    vrijeme_obrade[++k] = Obrada.IzracunajUzToleranciju(prag, tolerancija, arr1, arr2, false, false, false);

    prosjek_testa = 0.0d;
    for (int j = 0; j < broj_testova; j++)
        prosjek_testa += vrijeme_obrade[j];

    prosj_vrijeme_testova[i] = prosjek_testa / broj_testova;
}

prosjek_testa = 0.0d;
Console.WriteLine("--------- ANALIZA TESTIRANJA (za " + broj_ponavljanja + " ponavljanja) -------");
for (int j = 0; j < broj_ponavljanja; j++)
{
    Console.WriteLine("test " + (j + 1).ToString("#0") + ". = " + prosj_vrijeme_testova[j].ToString("##0.000") + " ms");
    prosjek_testa += prosj_vrijeme_testova[j];
}
Double  prosj_vrijeme_svih_testova = prosjek_testa / broj_ponavljanja;
Console.WriteLine("--------------------------------------------------");
Console.WriteLine("--Prosjek vremena svih testova: " + prosj_vrijeme_svih_testova.ToString("##0.000") + " ms");
Console.WriteLine("-----  Kraj obrade!   ------------------------");


Console.ReadKey();