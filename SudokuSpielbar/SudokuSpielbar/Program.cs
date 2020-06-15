using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSpielbar
{
    class Program
    {
        public static int[,] SpielFeld { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("##################################################################");
            Console.WriteLine("########### Willkommen beim Consolen-App Sudoku Spiel! ###########");
            Console.WriteLine("##################################################################");
            Console.WriteLine("Geben sie zum Spielen einen der Folgenden Schwierigkeitsgrade ein:");
            Console.WriteLine();
            Console.Write("Leicht (1)\nNormal (2)\nSchwer (3)\n\n");
            Console.WriteLine("Zum Laden eines Spiels geben sie bitte die (5) ein\nzum Beenden geben Sie bitte die (4) ein!");
            Console.WriteLine();
            Console.Write("Ihre Auswahl: ");
            int auswahl = Convert.ToInt32(Console.ReadLine());

            BenutzerEingabe(auswahl);
        }
        static void AnzeigeAktualisieren()
        {
            Console.Clear();
            SudokuAusgeben();
        }

        static void SudokuAusgeben()
        {
            /* Ausgabe wie folgt:
               1 2 3   4 5 6   7 8 9 x
              _______________________ 
           1 | 1 2 3 | 4 5 6 | 7 8 9 |
           2 | 1 2 3 | 4 5 6 | 7 8 9 |
           3 | 1 2 3 | 4 5 6 | 7 8 9 |
             |-----------------------|
           4 | 1 2 3 | 4 5 6 | 7 8 9 |
           5 | 1 2 3 | 4 5 6 | 7 8 9 |
           6 | 1 2 3 | 4 5 6 | 7 8 9 |
             |-----------------------|
           7 | 1 2 3 | 4 5 6 | 7 8 9 |
           8 | 1 2 3 | 4 5 6 | 7 8 9 |
           9 | 1 2 3 | 4 5 6 | 7 8 9 |
           y  ----------------------- 
            */
            Console.WriteLine("    1 2 3   4 5 6   7 8 9 x");
            Console.WriteLine("   ----------------------- ");
            for (int zeile = 0; zeile < 9; zeile++)
            {
                string zAktuell = AusgabeZeile(zeile);
                if (zAktuell.Contains("0"))
                {
                    zAktuell = zAktuell.Replace("0", " ");
                }
                if (zeile == 2 || zeile == 5)
                {
                    Console.Write("{0} | {1} {2} {3} | {4} {5} {6} | {7} {8} {9} |\n", zeile + 1, zAktuell[0], zAktuell[1], zAktuell[2], zAktuell[3], zAktuell[4], zAktuell[5], zAktuell[6], zAktuell[7], zAktuell[8]);
                    Console.WriteLine("  |-----------------------|");
                }
                else
                {
                    Console.Write("{0} | {1} {2} {3} | {4} {5} {6} | {7} {8} {9} |\n", zeile + 1, zAktuell[0], zAktuell[1], zAktuell[2], zAktuell[3], zAktuell[4], zAktuell[5], zAktuell[6], zAktuell[7], zAktuell[8]);
                }
            }
            Console.WriteLine("y  ----------------------- ");
            Console.WriteLine();
            Console.WriteLine("Tipp: Laden / Speichern / Beenden jederzeit durch eingeben von\n 'laden', 'speichern', 'beenden' .");
            Console.WriteLine();

            //eingabeAbfrage();
        }

        static string AusgabeZeile(int zeile)
        {
            string zeileAus = "";

            for (int s = 0; s < 9; s++)
            {
                zeileAus += Program.SpielFeld[s, zeile];
            }

            return zeileAus;
        }

        static void BenutzerEingabe(int auswahl)
        {
            switch (auswahl)
            {
                case 1:
                    Program.SpielFeld = new int[,] { { 0, 6, 3, 4, 2, 0, 8, 1, 7 }, { 0, 0, 2, 7, 3, 8, 0, 0, 0 }, { 7, 5, 0, 6, 0, 0, 0, 0, 0 },
                                             { 5, 9, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 1, 6, 9, 4 }, { 0, 0, 0, 0, 8, 4, 0, 0, 0 },
                                             { 0, 2, 0, 0, 7, 6, 0, 4, 5 }, { 1, 0, 6, 0, 0, 0, 0, 0, 9 }, { 3, 4, 0, 8, 9, 0, 7, 0, 0 }};
                    SpielAbfrage();
                    break;
                case 2:
                    Program.SpielFeld = new int[,] { { 9, 5, 0, 6, 7, 0, 1, 0, 0 }, { 0, 0, 2, 0, 0, 4, 5, 6, 0 }, { 1, 0, 0, 3, 9, 0, 2, 0, 0 },
                                             { 0, 1, 0, 0, 0, 6, 0, 4, 3 }, { 0, 6, 0, 0, 4, 8, 0, 0, 0 }, { 0, 4, 0, 0, 0, 3, 0, 2, 0 },
                                             { 5, 0, 7, 8, 0, 0, 0, 0, 0 }, { 0, 0, 8, 2, 0, 0, 0, 0, 7 }, { 0, 0, 0, 4, 0, 0, 9, 8, 2 }};
                    SpielAbfrage();
                    break;
                case 3:
                    Program.SpielFeld = new int[,] { { 8, 0, 0, 1, 0, 0, 7, 0, 5 }, { 5, 0, 0, 0, 0, 0, 0, 4, 1 }, { 0, 0, 0, 2, 0, 8, 9, 0, 0 },
                                             { 0, 0, 0, 0, 0, 0, 1, 3, 0 }, { 0, 0, 0, 8, 6, 9, 0, 0, 0 }, { 2, 7, 6, 0, 0, 0, 0, 0, 0 },
                                             { 0, 0, 0, 0, 0, 0, 3, 1, 9 }, { 9, 8, 2, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 5, 9, 4, 0, 0, 7 }};
                    SpielAbfrage();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Beende in 5 Sekunden!");
                    System.Threading.Thread.Sleep(5000);
                    break;

                default:
                    break;
            }
        }

        static void SpielAbfrage()
        {
            AnzeigeAktualisieren();
            Console.WriteLine("Bitte die Koordinaten der Stelle angeben. z.b.: 3,2");
            string coords = "";
            Console.Write("x, y: ");
            coords += Console.ReadLine();
            if (coords == "beenden")
            {
                BenutzerEingabe(4);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Welche Zahl soll an dieser Stelle eingetragen werden? 0 für Feld frei lassen.");
                string zahlEingabe = Console.ReadLine();
                if (zahlEingabe == "beenden")
                {
                    BenutzerEingabe(4);
                }
                else
                {
                    int zahl = Convert.ToInt32(zahlEingabe);
                    ZahlAendern(coords, zahl);
                    AnzeigeAktualisieren();
                    SpielAbfrage();
                }
            }
        }
        static void ZahlAendern(string coords, int zahl)
        {
            string[] splitCoords = coords.Split(',');
            int x = Convert.ToInt32(splitCoords[0].ToString()) - 1; //-1 da Spielfeld X von 0-8
            int y = Convert.ToInt32(splitCoords[1].ToString()) - 1; //-1 da Spielfeld Y von 0-8

            int zahlAlt = Program.SpielFeld[x, y];
            Program.SpielFeld[x, y] = zahl;
            AnzeigeAktualisieren();
            /*
             * Wenn Prüfung fehlschlägt: Ausgabe "Eingabe Ungültig! Rückgangig machen? J/N?"
             *      "Rückgängig machen? J/N"
             *      Wenn ja -> Feld an coords = zahlAlt
             *      Wenn nein -> Beibehalten, point of no return :D
             */
            if (!ZahlEingabePruefen(Program.SpielFeld, x, y))
            {
                Console.WriteLine("Eingabe ist Ungültig! Rückgängig machen? J/N");

                string antwort = Console.ReadLine().ToLower();
                if (antwort == "beenden")
                {
                    BenutzerEingabe(4);
                }
                else if (antwort == "j")
                {
                    Console.WriteLine();
                    Program.SpielFeld[x, y] = zahlAlt;
                    AnzeigeAktualisieren();
                    Console.WriteLine("Zahl wurde zurückgesetzt auf: " + zahlAlt + ". Beliebige Taste zum Bestätigen.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Zahl wird beibehalten. Beliebige Taste zum Bestätigen.");
                    Console.ReadKey();
                }

            }
        }

        /* Nicht funktional
        static void Laden()
        {
            Console.WriteLine("Bitte geben sie den Dateinamen an: ");
            string dateiName = Console.ReadLine();
            
            using (FileStream lesen = File.Open(dateiName, FileMode.Open, FileAccess.Read))
            {

            }
            //Hier der Code für das Auslesen des Streams (laden)
            //Hier aufruf der Methode zum Schließen
        } */

        /* Nicht funktional
        static void Speichern()
        {
            Console.WriteLine("Bitte geben sie den Dateinamen an: ");
            string dateiName = Console.ReadLine();

            using(FileStream schreiben = File.Open(dateiName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {

            }
            
            //Hier der Code für das Schreiben des Streams (speichern)
            //Hier aufruf der Methode zum Schließen
        } */

        static bool ZahlEingabePruefen(int[,] feld, int x, int y)
        {
            int teilFeld;
            if (x < 3)
            {
                if (y < 3)
                {
                    teilFeld = 0;
                }
                else if (y > 2 && y < 6)
                {
                    teilFeld = 3;
                }
                else
                {
                    teilFeld = 6;
                }
            }
            else if (x > 2 && x < 6)
            {
                if (y < 3)
                {
                    teilFeld = 1;
                }
                else if (y > 2 && y < 6)
                {
                    teilFeld = 4;
                }
                else
                {
                    teilFeld = 7;
                }
            }
            else
            {
                if (y < 3)
                {
                    teilFeld = 2;
                }
                else if (y > 2 && y < 6)
                {
                    teilFeld = 5;
                }
                else
                {
                    teilFeld = 8;
                }
            }

            if (!(pruefeSpalte(x, feld) && pruefeZeile(y, feld) && pruefeTeilfeld(teilFeld, feld)))
            {
                return false;
            }        
            return true;
        }

        static bool pruefeZeile(int zeile, int[,] spielFeld) //Bekommt übergeben welche Zeile zu Prüfen ist
        {
            int[] pruefZeile = new int[spielFeld.GetLength(0)];
            for (int z = 0; z < pruefZeile.Length; z++)
            {
                pruefZeile[z] = spielFeld[z, zeile];
            }
            return arrayPruefen(pruefZeile);
        }

        static bool pruefeSpalte(int spalte, int[,] spielFeld) //Bekommt übergeben welche Spalte zu Prüfen ist
        {
            int[] pruefSpalte = new int[spielFeld.GetLength(0)];
            for (int z = 0; z < pruefSpalte.Length; z++)
            {
                pruefSpalte[z] = spielFeld[spalte, z];
            }
            return arrayPruefen(pruefSpalte);
        }

        static bool pruefeTeilfeld(int teilfeld, int[,] spielFeld) //Bekommt übergeben welches Teilfeld zu Prüfen ist
        {
            int[][] teilFelder = new int[9][];
            teilFelder[0] = new int[] { spielFeld[0, 0], spielFeld[0, 1], spielFeld[0, 2], spielFeld[1, 0], spielFeld[1, 1], spielFeld[1, 2], spielFeld[2, 0], spielFeld[2, 1], spielFeld[2, 2] };
            teilFelder[1] = new int[] { spielFeld[3, 0], spielFeld[3, 1], spielFeld[3, 2], spielFeld[4, 0], spielFeld[4, 1], spielFeld[4, 2], spielFeld[5, 0], spielFeld[5, 1], spielFeld[5, 2] };
            teilFelder[2] = new int[] { spielFeld[6, 0], spielFeld[6, 1], spielFeld[6, 2], spielFeld[7, 0], spielFeld[7, 1], spielFeld[7, 2], spielFeld[8, 0], spielFeld[8, 1], spielFeld[8, 2] };
            teilFelder[3] = new int[] { spielFeld[0, 3], spielFeld[0, 4], spielFeld[0, 5], spielFeld[1, 3], spielFeld[1, 4], spielFeld[1, 5], spielFeld[2, 3], spielFeld[2, 4], spielFeld[2, 5] };
            teilFelder[4] = new int[] { spielFeld[3, 3], spielFeld[3, 4], spielFeld[3, 5], spielFeld[4, 3], spielFeld[4, 4], spielFeld[4, 5], spielFeld[5, 3], spielFeld[5, 4], spielFeld[5, 5] };
            teilFelder[5] = new int[] { spielFeld[6, 3], spielFeld[6, 4], spielFeld[6, 5], spielFeld[7, 3], spielFeld[7, 4], spielFeld[7, 5], spielFeld[8, 3], spielFeld[8, 4], spielFeld[8, 5] };
            teilFelder[6] = new int[] { spielFeld[0, 6], spielFeld[0, 7], spielFeld[0, 8], spielFeld[1, 6], spielFeld[1, 7], spielFeld[1, 8], spielFeld[2, 6], spielFeld[2, 7], spielFeld[2, 8] };
            teilFelder[7] = new int[] { spielFeld[3, 6], spielFeld[3, 7], spielFeld[3, 8], spielFeld[4, 6], spielFeld[4, 7], spielFeld[4, 8], spielFeld[5, 6], spielFeld[5, 7], spielFeld[5, 8] };
            teilFelder[8] = new int[] { spielFeld[6, 6], spielFeld[6, 7], spielFeld[6, 8], spielFeld[7, 6], spielFeld[7, 7], spielFeld[7, 8], spielFeld[8, 6], spielFeld[8, 7], spielFeld[8, 8] };

            return arrayPruefen(teilFelder[teilfeld]);
        }

        static bool arrayPruefen(int[] array)
        {
            foreach (int zahl in array)
            {
                int anzahl = 0;
                for (int f = 0; f < array.Length; f++)
                {
                    if (array[f] == zahl && zahl != 0)
                    {
                        anzahl++;
                        if (anzahl > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}