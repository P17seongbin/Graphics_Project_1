using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBJ_MAKER
{
    public class Object4D
    {
        public List<Tuple<float, float, float, float>> v;
        public List<Tuple<float, float, float, float>> n;
        public List<Tuple<int, int, int, int, int, int>> f;
        public List<Tuple<int, int>> l;
    }
    class HyperCube : Object4D
    {
        public HyperCube()
        {
            v = new List<Tuple<float, float, float, float>>();
            n = new List<Tuple<float, float, float, float>>();
            List<Tuple<int, int, int, int, int, int>> newf = new List<Tuple<int, int, int, int, int, int>>();
            f = new List<Tuple<int, int, int, int, int, int>>(); 
            l = new List<Tuple<int, int>>();

            l.Add(new Tuple<int, int>(0, 1));
            l.Add(new Tuple<int, int>(0, 2));
            l.Add(new Tuple<int, int>(0, 4));
            l.Add(new Tuple<int, int>(0, 8));

            l.Add(new Tuple<int, int>(1, 3));
            l.Add(new Tuple<int, int>(1, 5));
            l.Add(new Tuple<int, int>(1, 9));

            l.Add(new Tuple<int, int>(2, 3));
            l.Add(new Tuple<int, int>(2, 6));
            l.Add(new Tuple<int, int>(2, 6));

            l.Add(new Tuple<int, int>(3, 7));
            l.Add(new Tuple<int, int>(3, 10));

            l.Add(new Tuple<int, int>(4, 5));
            l.Add(new Tuple<int, int>(4, 6));
            l.Add(new Tuple<int, int>(4, 12));

            l.Add(new Tuple<int, int>(5, 7));
            l.Add(new Tuple<int, int>(5, 13));

            l.Add(new Tuple<int, int>(6, 7));
            l.Add(new Tuple<int, int>(6, 14));

            l.Add(new Tuple<int, int>(7, 15));

            l.Add(new Tuple<int, int>(8, 9));
            l.Add(new Tuple<int, int>(8, 10));
            l.Add(new Tuple<int, int>(8, 12));

            l.Add(new Tuple<int, int>(9, 11));
            l.Add(new Tuple<int, int>(9, 13));

            l.Add(new Tuple<int, int>(10, 11));
            l.Add(new Tuple<int, int>(10, 14));

            l.Add(new Tuple<int, int>(11, 15));

            l.Add(new Tuple<int, int>(12, 13));
            l.Add(new Tuple<int, int>(12, 14));

            l.Add(new Tuple<int, int>(13, 15));

            l.Add(new Tuple<int, int>(14, 15));


            v.Add(new Tuple<float, float, float, float>(-.5f, -0.5f, -0.5f, -0.5f));//0
            v.Add(new Tuple<float, float, float, float>(0.5f, -0.5f, -0.5f, -0.5f));//1
            v.Add(new Tuple<float, float, float, float>(-0.5f, 0.5f, -0.5f, -0.5f));//2
            v.Add(new Tuple<float, float, float, float>(0.5f, 0.5f, -0.5f, -0.5f));//3
            v.Add(new Tuple<float, float, float, float>(-0.5f, -0.5f, 0.5f, -0.5f));//4
            v.Add(new Tuple<float, float, float, float>(0.5f, -0.5f, 0.5f, -0.5f));//5
            v.Add(new Tuple<float, float, float, float>(-0.5f, 0.5f, 0.5f, -0.5f));//6
            v.Add(new Tuple<float, float, float, float>(0.5f, 0.5f, 0.5f, -0.5f));//7

            v.Add(new Tuple<float, float, float, float>(-0.5f, -0.5f, -0.5f, 0.5f));//8
            v.Add(new Tuple<float, float, float, float>(0.5f, -0.5f, -0.5f, 0.5f));//9
            v.Add(new Tuple<float, float, float, float>(-0.5f, 0.5f, -0.5f, 0.5f));//10
            v.Add(new Tuple<float, float, float, float>(0.5f, 0.5f, -0.5f, 0.5f));//11
            v.Add(new Tuple<float, float, float, float>(-0.5f, -0.5f, 0.5f, 0.5f));//12
            v.Add(new Tuple<float, float, float, float>(0.5f, -0.5f, 0.5f, 0.5f));//13
            v.Add(new Tuple<float, float, float, float>(-0.5f, 0.5f, 0.5f, 0.5f));//14
            v.Add(new Tuple<float, float, float, float>(0.5f, 0.5f, 0.5f, 0.5f));//15

            n.Add(new Tuple<float, float, float, float>(1, 0, 0, 0));//0
            n.Add(new Tuple<float, float, float, float>(-1, 0, 0, 0));//1
            n.Add(new Tuple<float, float, float, float>(0, 1, 0, 0));//2
            n.Add(new Tuple<float, float, float, float>(0, -1, 0, 0));//3
            n.Add(new Tuple<float, float, float, float>(0, 0, 1, 0));//4
            n.Add(new Tuple<float, float, float, float>(0, 0, -1, 0));//5
            n.Add(new Tuple<float, float, float, float>(0, 0, 0, 1));//6
            n.Add(new Tuple<float, float, float, float>(0, 0, 0, -1));//7

            {
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 4, 6, 7, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 5, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 5, 6, 4, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(7, 6, 4, 6, 5, 6));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 4, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 4, 6, 6, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 6, 6, 7, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 6, 7, 6, 6, 6));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 1, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 1, 6, 5, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 5, 6, 7, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 6, 7, 6, 5, 6));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 2, 6, 7, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 6, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 6, 6, 2, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(7, 6, 2, 6, 6, 6));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 3, 6, 1, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 1, 6, 7, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 3, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 6, 3, 6, 7, 6));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 2, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 2, 6, 3, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 6, 3, 6, 7, 6));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 6, 7, 6, 3, 6));
            }

            {
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 12, 7, 15, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 13, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 13, 7, 12, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 7, 12, 7, 13, 7));

                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 12, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 12, 7, 14, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 14, 7, 15, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(12, 7, 15, 7, 14, 7));

                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 9, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 9, 7, 13, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 13, 7, 15, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(9, 7, 15, 7, 13, 7));

                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 10, 7, 15, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 14, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 14, 7, 10, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 7, 10, 7, 14, 7));

                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 11, 7, 9, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 9, 7, 15, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 11, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(9, 7, 11, 7, 15, 7));

                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 10, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 10, 7, 11, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 7, 11, 7, 15, 7));
                newf.Add(new Tuple<int, int, int, int, int, int>(10, 7, 15, 7, 11, 7));
            }
            ////
            {
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 8, 4, 11, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 9, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 9, 4, 8, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(11, 4, 8, 4, 9, 4));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 8, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 8, 4, 10, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 10, 4, 11, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 4, 11, 4, 10, 4));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 1, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 1, 4, 9, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 9, 4, 11, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 4, 11, 4, 9, 4));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 2, 4, 11, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 10, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 10, 4, 2, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(11, 4, 2, 4, 10, 4));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 3, 4, 1, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 1, 4, 11, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 3, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 4, 3, 4, 11, 4));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 2, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 2, 4, 3, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 4, 3, 4, 11, 4));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 4, 11, 4, 3, 4));
            }

            {
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 12, 5, 15, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 13, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 13, 5, 12, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 5, 12, 5, 13, 5));

                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 12, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 12, 5, 14, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 14, 5, 15, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(12, 5, 15, 5, 14, 5));

                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 5, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 5, 5, 13, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 13, 5, 15, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(5, 5, 15, 5, 13, 5));

                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 6, 5, 15, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 14, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 14, 5, 6, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 5, 6, 5, 14, 5));

                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 7, 5, 5, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 5, 5, 15, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 7, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(5, 5, 7, 5, 15, 5));

                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 6, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 6, 5, 7, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 5, 7, 5, 15, 5));
                newf.Add(new Tuple<int, int, int, int, int, int>(6, 5, 15, 5, 7, 5));
            }
            ////
            {
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 4, 2, 13, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 5, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 5, 2, 4, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(13, 2, 4, 2, 5, 2));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 4, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 4, 2, 12, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 12, 2, 13, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 2, 13, 2, 12, 2));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 1, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 1, 2, 5, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 5, 2, 13, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 2, 13, 2, 5, 2));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 8, 2, 13, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 12, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 12, 2, 8, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(13, 2, 8, 2, 12, 2));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 9, 2, 1, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 1, 2, 13, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 9, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 2, 9, 2, 13, 2));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 8, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 8, 2, 9, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 2, 9, 2, 13, 2));
                newf.Add(new Tuple<int, int, int, int, int, int>(8, 2, 13, 2, 9, 2));
            }

            {
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 6, 3, 15, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 7, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 7, 3, 6, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 3, 6, 3, 7, 3));

                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 6, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 6, 3, 14, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 14, 3, 15, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(6, 3, 15, 3, 14, 3));

                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 3, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 3, 3, 7, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 7, 3, 15, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(3, 3, 15, 3, 7, 3));

                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 10, 3, 15, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 14, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 14, 3, 10, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 3, 10, 3, 14, 3));

                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 11, 3, 3, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 3, 3, 15, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 11, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(3, 3, 11, 3, 15, 3));

                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 10, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 10, 3, 11, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(2, 3, 11, 3, 15, 3));
                newf.Add(new Tuple<int, int, int, int, int, int>(10, 3, 15, 3, 11, 3));
            }
            ////
            {
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 4, 0, 14, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 12, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 12, 0, 4, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(14, 0, 4, 0, 12, 0));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 4, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 4, 0, 6, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 6, 0, 14, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(4, 0, 14, 0, 4, 0));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 8, 0, 14, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 12, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 12, 0, 8, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(14, 0, 8, 0, 12, 0));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 2, 0, 14, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 6, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 6, 0, 2, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(14, 0, 2, 0, 6, 0));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 8, 0, 10, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 10, 0, 14, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 8, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(10, 0, 8, 0, 14, 0));

                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 2, 0, 14, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 10, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(0, 0, 10, 0, 2, 0));
                newf.Add(new Tuple<int, int, int, int, int, int>(14, 0, 2, 0, 10, 0));
            }

            {
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 5, 1, 15, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 13, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 13, 1, 5, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 1, 5, 1, 13, 1));

                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 5, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 5, 1, 7, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 7, 1, 15, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(5, 1, 15, 1, 7, 1));

                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 9, 1, 15, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 13, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 13, 1, 9, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 1, 9, 1, 13, 1));

                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 3, 1, 15, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 7, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 7, 1, 3, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(15, 1, 3, 1, 7, 1));

                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 9, 1, 11, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 11, 1, 15, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 9, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(11, 1, 9, 1, 15, 1));

                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 3, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 3, 1, 11, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(1, 1, 11, 1, 15, 1));
                newf.Add(new Tuple<int, int, int, int, int, int>(3, 1, 15, 1, 11, 1));
            }
            foreach(var face in newf)
            {
                f.Add(new Tuple<int, int, int, int, int, int>(face.Item1, face.Item2, face.Item5, face.Item4, face.Item3, face.Item6));
            }
        }
    }
    class Simplex4 : Object4D
    {
        public Simplex4()
        {
            v = new List<Tuple<float, float, float, float>>();
            n = new List<Tuple<float, float, float, float>>();
            f = new List<Tuple<int, int, int, int, int, int>>();
            l = new List<Tuple<int, int>>();

            l.Add(new Tuple<int, int>(0, 1));
            l.Add(new Tuple<int, int>(0, 2));
            l.Add(new Tuple<int, int>(0, 4));
            l.Add(new Tuple<int, int>(0, 8));

            l.Add(new Tuple<int, int>(1, 3));
            l.Add(new Tuple<int, int>(1, 5));
            l.Add(new Tuple<int, int>(1, 9));

            l.Add(new Tuple<int, int>(2, 3));


            v.Add(new Tuple<float, float, float, float>(0, 0, 0, 0));//0
            v.Add(new Tuple<float, float, float, float>(1, 0, 0, 0));//1
            v.Add(new Tuple<float, float, float, float>(0, 1, 0, 0));//2
            v.Add(new Tuple<float, float, float, float>(0, 0, 1, 0));//3
            v.Add(new Tuple<float, float, float, float>(0, 0, 0, 1));//4

            n.Add(new Tuple<float, float, float, float>(1, 0, 0, 0));//0
            n.Add(new Tuple<float, float, float, float>(-1, 0, 0, 0));//1
            n.Add(new Tuple<float, float, float, float>(0, 1, 0, 0));//2
            n.Add(new Tuple<float, float, float, float>(0, -1, 0, 0));//3
            n.Add(new Tuple<float, float, float, float>(0, 0, 1, 0));//4
            n.Add(new Tuple<float, float, float, float>(0, 0, -1, 0));//5
            n.Add(new Tuple<float, float, float, float>(0, 0, 0, 1));//6
            n.Add(new Tuple<float, float, float, float>(0, 0, 0, -1));//7

            {
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 4, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 4, 6, 5, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 5, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 6, 5, 6, 7, 6));
            }
        }
    }

    class ParametrizedObject : Object4D
    {
        private float theta_min, theta_max, phi_min, phi_max;
        private float r;
        private int N;
        public ParametrizedObject(float _r, float _theta_min, float _theta_max, float _phi_min, float _phi_max)
        {
            N = 50;
            r = _r;
            theta_min = _theta_min;
            theta_max = _theta_max;
            phi_min = _phi_min;
            phi_max = _phi_max;
            v = new List<Tuple<float, float, float, float>>();
            n = new List<Tuple<float, float, float, float>>();
            f = new List<Tuple<int, int, int, int, int, int>>();
            l = new List<Tuple<int, int>>();
            draw();
        }
        private void draw()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    v.Add(new Tuple<float, float, float, float>(r * (float)Math.Cos(theta_min + (theta_max - theta_min) * i / N), r * (float)Math.Sin(theta_min + (theta_max - theta_min) * i / N),
                        r * (float)Math.Cos(phi_min + (phi_max - phi_min) * j / N), r * (float)Math.Sin(phi_min + (phi_max - phi_min) * j / N)));
                    n.Add(new Tuple<float, float, float, float>(-r * (float)Math.Sin(theta_min + (theta_max - theta_min) * i / N), r * (float)Math.Cos(theta_min + (theta_max - theta_min) * i / N),
                        -r * (float)Math.Sin(phi_min + (phi_max - phi_min) * j / N), r * (float)Math.Cos(phi_min + (phi_max - phi_min) * j / N)));
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    l.Add(new Tuple<int, int>(N * i + j, N * i + ((j + 1) % N)));
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    l.Add(new Tuple<int, int>(N * i + j, N * ((i + 1) % N) + j));
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    f.Add(new Tuple<int, int, int, int, int, int>(N * i + j, N * i + j,
                        N * i + ((j + 1) % N), N * i + ((j + 1) % N),
                        N * ((i + 1) % N) + j, N * ((i + 1) % N) + j));
                    f.Add(new Tuple<int, int, int, int, int, int>(N * ((i + 1) % N) + ((j + 1) % N), N * ((i + 1) % N) + ((j + 1) % N),
                         N * ((i + 1) % N) + j, N * ((i + 1) % N) + j,
                         N * i + ((j + 1) % N), N * i + ((j + 1) % N)));
                }
            }
        }
    }
    class Obj_maker
    {
        static void Main()
        {
            string docPath = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(docPath);

            Write();
            WriteCliffordTorus();
        }
        static void Write()
        {
            string docPath = System.IO.Directory.GetCurrentDirectory();

            HyperCube hyperCube = new HyperCube();

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "HyperCube.txt")))
            {
                foreach (Tuple<float, float, float, float> vline in hyperCube.v)
                {
                    outputFile.WriteLine("v " + vline.Item1 + " " + vline.Item2 + " " + vline.Item3 + " " + vline.Item4);
                }
                outputFile.WriteLine("# " + hyperCube.v.Count + " vertices" + '\n');

                foreach (Tuple<float, float, float, float> nline in hyperCube.n)
                {
                    outputFile.WriteLine("vn " + nline.Item1 + " " + nline.Item2 + " " + nline.Item3 + " " + nline.Item4);
                }
                outputFile.WriteLine("# " + hyperCube.n.Count + " vertex normals" + '\n');

                foreach (Tuple<int, int, int, int, int, int> fline in hyperCube.f)
                {
                    outputFile.WriteLine("f " + fline.Item1 + "/" + fline.Item2 + " " + fline.Item3 + "/" + fline.Item4 + " " + fline.Item5 + "/" + fline.Item6);
                }
                outputFile.WriteLine("# " + hyperCube.f.Count + " faces" + '\n');

                foreach (Tuple<int, int> fline in hyperCube.l)
                {
                    outputFile.WriteLine("l " + fline.Item1 + "/" + fline.Item2);
                }
                outputFile.WriteLine("# " + hyperCube.l.Count + " lines");
            }
        }

        static void WriteCliffordTorus()
        {
            string docPath = System.IO.Directory.GetCurrentDirectory();

            ParametrizedObject CliffordTorus = new ParametrizedObject((1 / (float)Math.Sqrt(2)), 0, 2 * (float)Math.PI, 0, 2 * (float)Math.PI);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "CliffordTorus.obj")))
            {
                foreach (Tuple<float, float, float, float> vline in CliffordTorus.v)
                {
                    outputFile.WriteLine("v " + vline.Item1 + " " + vline.Item2 + " " + vline.Item3 + " " + vline.Item4);
                }
                outputFile.WriteLine("# " + CliffordTorus.v.Count + " vertices" + '\n');

                foreach (Tuple<float, float, float, float> nline in CliffordTorus.n)
                {
                    outputFile.WriteLine("vn " + nline.Item1 + " " + nline.Item2 + " " + nline.Item3 + " " + nline.Item4);
                }
                outputFile.WriteLine("# " + CliffordTorus.n.Count + " vertex normals" + '\n');

                foreach (Tuple<int, int, int, int, int, int> fline in CliffordTorus.f)
                {
                    outputFile.WriteLine("f " + fline.Item1 + "/" + fline.Item2 + " " + fline.Item3 + "/" + fline.Item4 + " " + fline.Item5 + "/" + fline.Item6);
                }
                outputFile.WriteLine("# " + CliffordTorus.f.Count + " faces" + '\n');

                foreach (Tuple<int, int> fline in CliffordTorus.l)
                {
                    outputFile.WriteLine("l " + fline.Item1 + "/" + fline.Item2);
                }
                outputFile.WriteLine("# " + CliffordTorus.l.Count + " lines");
            }
        }
    }
}
