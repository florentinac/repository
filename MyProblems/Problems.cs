﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProblems
{
    public class Problems
    {
        public string Pepene(int X)
        {
            // X reprezinta nr de kg 
            if (X % 2 != 0)
                return "NU";
            else
                return "DA";
        }

        public int Sportiv(int N)
        {
            //1+2+3+..N+(N-1)+(N-2)+...+1
            //pt N=3=> 1+2+3+2+1=9
            //pt N=4=> 1+2+3+4+3+2+1=16
            return N * N;
        }

        public int Capre(int Q_capre, int W_zile)
        {
            //Y capre mananca intr-o zi Z_fan/X_zile
            //o capra mananca intr-o zi Z_fan/(X_zile*Y_capre)
            //atunci Q_capre mananca in W_zile (Z_fan/X_Zile*Y_capre)*Q_capre*W_zile
            int X_zile = 10;
            int Y_capre = 12;
            int Z_fan = 30;

            return (Z_fan / X_zile * Y_capre) * Q_capre * W_zile;
        }

        public int[] Ciuperci(int N, int X)
        {
            //ciuperci_albe+X*ciuperci_albe=N
            int ciuperci_albe = 0;
            int ciuperci_rosii = 0;
            ciuperci_albe = N / (X + 1);
            ciuperci_rosii = X * ciuperci_albe;
            var ciuperci = new int[] { ciuperci_albe, ciuperci_rosii };

            return ciuperci;
        }

        public double Parchet(int N, int M)
        {
            int A = 4;
            int B = 10;
            double mp_parchet= (N / A) * (M / B); 
            return mp_parchet + 15 * mp_parchet / 100; 
        }

        public int Pavaj (int N, int M)
        {
            int A = 4;
            int mp_parchet = (int)Math.Ceiling((double)N/A) * (int)Math.Ceiling((double)M / A);
            return mp_parchet;
        }

        public double Rata(int imprumut, double dobanda, int durata)
        {
            float capital = 0;
            double dobanda_lunara = 0;
            double rata = 0;
            capital = imprumut / (durata*12);
            dobanda_lunara = dobanda / 12;
            rata = capital + dobanda_lunara / 100 * (imprumut - capital * 52);
            return rata;          
        }
        public double Tren(int distanta, int viteza_tren)
        {
            double timp = 0;
            double distanta_pasare = 0;
            timp = distanta/ viteza_tren;
            distanta_pasare = timp * 2 * viteza_tren;

            return distanta_pasare;

        }
    }
}
