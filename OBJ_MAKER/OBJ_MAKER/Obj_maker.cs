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


            v.Add(new Tuple<float, float, float, float>(0, 0, 0, 0));//0
            v.Add(new Tuple<float, float, float, float>(1, 0, 0, 0));//1
            v.Add(new Tuple<float, float, float, float>(0, 1, 0, 0));//2
            v.Add(new Tuple<float, float, float, float>(1, 1, 0, 0));//3
            v.Add(new Tuple<float, float, float, float>(0, 0, 1, 0));//4
            v.Add(new Tuple<float, float, float, float>(1, 0, 1, 0));//5
            v.Add(new Tuple<float, float, float, float>(0, 1, 1, 0));//6
            v.Add(new Tuple<float, float, float, float>(1, 1, 1, 0));//7

            v.Add(new Tuple<float, float, float, float>(0, 0, 0, 1));//8
            v.Add(new Tuple<float, float, float, float>(1, 0, 0, 1));//9
            v.Add(new Tuple<float, float, float, float>(0, 1, 0, 1));//10
            v.Add(new Tuple<float, float, float, float>(1, 1, 0, 1));//11
            v.Add(new Tuple<float, float, float, float>(0, 0, 1, 1));//12
            v.Add(new Tuple<float, float, float, float>(1, 0, 1, 1));//13
            v.Add(new Tuple<float, float, float, float>(0, 1, 1, 1));//14
            v.Add(new Tuple<float, float, float, float>(1, 1, 1, 1));//15

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
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 4, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 4, 6, 6, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 6, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 6, 6, 6, 7, 6));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 1, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 1, 6, 5, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 7, 6, 5, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 6, 7, 6, 5, 6));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 2, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 2, 6, 6, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 6, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 6, 6, 6, 7, 6));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 1, 6, 3, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 1, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 3, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 6, 3, 6, 7, 6));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 2, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 2, 6, 3, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 6, 3, 6, 7, 6));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 6, 3, 6, 7, 6));
            }

            {
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 12, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 12, 7, 13, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 13, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(12, 7, 13, 7, 15, 7));

                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 12, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 12, 7, 14, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 14, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(12, 7, 14, 7, 15, 7));

                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 9, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 9, 7, 13, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 15, 7, 13, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(9, 7, 15, 7, 13, 7));

                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 10, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 10, 7, 14, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 14, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(10, 7, 14, 7, 15, 7));

                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 9, 7, 11, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 9, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 11, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(9, 7, 11, 7, 15, 7));

                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 10, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 10, 7, 11, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 7, 11, 7, 15, 7));
                f.Add(new Tuple<int, int, int, int, int, int>(10, 7, 11, 7, 15, 7));
            }
            ////
            {
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 8, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 8, 4, 9, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 9, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 4, 9, 4, 11, 4));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 8, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 8, 4, 10, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 10, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 4, 10, 4, 11, 4));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 1, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 1, 4, 9, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 11, 4, 9, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 4, 11, 4, 9, 4));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 2, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 2, 4, 10, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 10, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 4, 10, 4, 11, 4));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 1, 4, 3, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 1, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 3, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 4, 3, 4, 11, 4));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 2, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 2, 4, 3, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 4, 3, 4, 11, 4));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 4, 3, 4, 11, 4));
            }

            {
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 12, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 12, 5, 13, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 13, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(12, 5, 13, 5, 15, 5));

                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 12, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 12, 5, 14, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 14, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(12, 5, 14, 5, 15, 5));

                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 5, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 5, 5, 13, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 15, 5, 13, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(5, 5, 15, 5, 13, 5));

                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 6, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 6, 5, 14, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 14, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(6, 5, 14, 5, 15, 5));

                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 5, 5, 7, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 5, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 7, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(5, 5, 7, 5, 15, 5));

                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 6, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 6, 5, 7, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 5, 7, 5, 15, 5));
                f.Add(new Tuple<int, int, int, int, int, int>(6, 5, 7, 5, 15, 5));
            }
            ////
            {
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 4, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 4, 2, 5, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 5, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 2, 5, 2, 13, 2));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 4, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 4, 2, 12, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 12, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 2, 12, 2, 13, 2));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 1, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 1, 2, 5, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 13, 2, 5, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 2, 13, 2, 5, 2));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 8, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 8, 2, 12, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 12, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 2, 12, 2, 13, 2));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 1, 2, 9, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 1, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 9, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 2, 9, 2, 13, 2));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 8, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 8, 2, 9, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 2, 9, 2, 13, 2));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 2, 9, 2, 13, 2));
            }

            {
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 6, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 6, 3, 7, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 7, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(6, 3, 7, 3, 15, 3));

                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 6, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 6, 3, 14, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 14, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(6, 3, 14, 3, 15, 3));

                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 3, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 3, 3, 7, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 15, 3, 7, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(3, 3, 15, 3, 7, 3));

                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 10, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 10, 3, 14, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 14, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(10, 3, 14, 3, 15, 3));

                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 3, 3, 11, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 3, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 11, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(3, 3, 11, 3, 15, 3));

                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 10, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 10, 3, 11, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 3, 11, 3, 15, 3));
                f.Add(new Tuple<int, int, int, int, int, int>(10, 3, 11, 3, 15, 3));
            }
            ////
            {
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 4, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 4, 0, 12, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 12, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 0, 12, 0, 14, 0));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 4, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 4, 0, 6, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 6, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(4, 0, 6, 0, 14, 0));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 8, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 8, 0, 12, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 14, 0, 12, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 0, 14, 0, 12, 0));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 2, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 2, 0, 6, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 6, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 0, 6, 0, 14, 0));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 8, 0, 10, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 8, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 10, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(8, 0, 10, 0, 14, 0));

                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 2, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 2, 0, 10, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(0, 0, 10, 0, 14, 0));
                f.Add(new Tuple<int, int, int, int, int, int>(2, 0, 10, 0, 14, 0));
            }

            {
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 5, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 5, 1, 13, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 13, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(5, 1, 13, 1, 15, 1));

                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 5, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 5, 1, 7, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 7, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(5, 1, 7, 1, 15, 1));

                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 9, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 9, 1, 13, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 15, 1, 13, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(9, 1, 15, 1, 13, 1));

                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 3, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 3, 1, 7, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 7, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(3, 1, 7, 1, 15, 1));

                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 9, 1, 11, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 9, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 11, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(9, 1, 11, 1, 15, 1));

                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 3, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 3, 1, 11, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(1, 1, 11, 1, 15, 1));
                f.Add(new Tuple<int, int, int, int, int, int>(3, 1, 11, 1, 15, 1));
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
        }
        static void Write()
        {
            string docPath = System.IO.Directory.GetCurrentDirectory();

            HyperCube hyperCube = new HyperCube();

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
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
    }
}
