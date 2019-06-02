using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartoLogic
{
    class OptermizeAlgorithm
    {

        public int singleNumber(int[] searchArray)
        {
            //this is the normal run of the mill situation I'd use, the advantage being less code and mostly bettr optamization
            //var singleNumbers = searchArray.GroupBy(X => X).Where(Y => Y.ToList().Count() == 1).Select(Z => Z.Key).ToList();

            //if(singleNumbers.Count() == 1)
            //{
            //    return singleNumbers.First();
            //}
            //else
            //{
            //    //Substitute for negative resut or throw exception as appropritate
            //    return -1;
            //}


            //This is built for the original code excluding Linq;
            int checkedPossition = 0;
            bool found = false;
            foreach(var searchValue in searchArray)
            {                
                for (int i = checkedPossition; checkedPossition < searchArray.Length; i++)
                {
                    if(searchValue == searchArray[i])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) return searchValue;
                checkedPossition++;
                found = false;
            }

            return -1;

        }



    }
}
