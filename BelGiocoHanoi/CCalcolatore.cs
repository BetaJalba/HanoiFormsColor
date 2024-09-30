using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelGiocoHanoi
{
    public class CCalcolatore
    {
        int numeroDischi;
        int[] colonne;
        int passo;
        bool onlyOnce;
        List<int[]> soluzione;

        public CCalcolatore(int numeroDischi) 
        {
            this.numeroDischi = numeroDischi;
            colonne = new int[3];
            colonne[0] = (int)Math.Pow(2, numeroDischi) - 1;
            passo = 1;
            onlyOnce = false;
            soluzione = new List<int[]>();
            soluzione.Add(colonne.ToArray()); //passa una copia
        }

        public void AvviaGioco() 
        {
            risolvi(numeroDischi);
        }

        private void risolvi(int n) 
        {
            if (!onlyOnce)
            {
                colonne[0] = (int)Math.Pow(2, n) - 1;
                onlyOnce = true;
            }

            //parte iterativa

            int posDiscoPiccolo = 0;

            for (int i = 0; i < 3; i++)
            {
                if (colonne[i] % 2 == 1)
                    posDiscoPiccolo = i;
            }

            if (n % 2 == 0)
            {
                switch (passo)
                {
                    case 1: //muove il disco più piccolo a dx
                        calcolaMossa(posDiscoPiccolo, posDiscoPiccolo + 1);
                        break;
                    case 2:
                        calcolaMossa(posDiscoPiccolo + 1, posDiscoPiccolo - 1);
                        break;
                }
            }
            else
            {
                switch (passo)
                {
                    case 1: //muove il disco più piccolo a sx
                        calcolaMossa(posDiscoPiccolo, posDiscoPiccolo - 1);
                        break;
                    case 2:
                        calcolaMossa(posDiscoPiccolo + 1, posDiscoPiccolo - 1);
                        break;
                }
            }

            if (colonne[2] == (int)Math.Pow(2, n) - 1)
                return;

            if (passo == 2)
                passo = 0;

            passo++;

            risolvi(n);
        }

        private void calcolaMossa(int p, int f) 
        {
            //si pensi all'array come se le due estremità fossero connesse
            if (f > 2)
                f = 0;
            else if (f < 0)
                f = 2;
            if (p > 2)
                p = 0;
            else if (p < 0)
                p = 2;

            int vPezzo = colonne[p];
            int vPezzof = colonne[f];
            int esponente;

            if (vPezzo != 0) //se la partenza è colonna vuota la mossa inversa è garantita
            {
                esponente = (int)Math.Truncate(Math.Log2(colonne[p]));

                while ((int)Math.Pow(2, esponente) != vPezzo) //calcolo del valore del primo pezzo
                {
                    if ((int)Math.Pow(2, esponente) <= vPezzo)
                    {
                        vPezzo -= (int)Math.Pow(2, esponente);
                    }
                    esponente--;
                }

                if (vPezzof != 0)
                {
                    esponente = (int)Math.Truncate(Math.Log2(colonne[f]));

                    while ((int)Math.Pow(2, esponente) != vPezzof) //calcolo del valore del secondo pezzo
                    {
                        if ((int)Math.Pow(2, esponente) <= vPezzof)
                        {
                            vPezzof -= (int)Math.Pow(2, esponente);
                        }
                        esponente--;
                    }
                }

                if ((vPezzo < vPezzof || vPezzof == 0))
                {
                    colonne[p] -= vPezzo;
                    colonne[f] += vPezzo;
                    soluzione.Add(colonne.ToArray());
                    return;
                }
            }

            //ridondante ma non avevo voglia di migliorarlo
            vPezzo = colonne[f];
            esponente = (int)Math.Truncate(Math.Log2(colonne[f]));

            while ((int)Math.Pow(2, esponente) != vPezzo) //calcolo del valore del secondo pezzo
            {
                if ((int)Math.Pow(2, esponente) <= vPezzo)
                {
                    vPezzo -= (int)Math.Pow(2, esponente);
                }
                esponente--;
            }
            colonne[f] -= vPezzo;
            colonne[p] += vPezzo;
            soluzione.Add(colonne.ToArray());
        }

        public int[] GetPosizioneDischi(int passo) 
        {
            try 
            {
                return soluzione[passo].ToArray(); //passa una copia
            }
            catch
            {
                throw new Exception(); //out of bounds
            }
        }
    }
}
