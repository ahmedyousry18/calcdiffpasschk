using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class CashReg
    {
        public double diff;
        public double ch_val;
        public double pp_val;
        public double[] Units = { 0.01, 0.05, 0.10, 0.25, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00 };
        string[] UnitsW = { "PENNY", "NICKEL", "DIME", "QUARTER", "HALFDOLLAR", "ONE", "TWO", "FIVE", "TEN", "TWENTY", "FIFTY" };
        public int counter;

        public string codes = "";
        public void CalcDiff(double CH, double PP)
        {
            CH = Math.Round(CH, 2);
            PP = Math.Round(PP, 2);

            ch_val = CH;
            pp_val = PP;

            diff = Math.Round(CH - PP, 2);

            Console.WriteLine("Purchase Product is (" + PP + ") - Cash Given (" + CH + ") = " + Math.Round(diff, 2) + "");

            foreach (double i in Units)
            {

                if (diff >= i)
                {
                    counter = counter + 1;
                }
            }

            for (int j = counter - 1; j >= 0 ; j--)
            {
                if(diff >= Units[counter - 1])
                {
                    diff = diff - Units[counter - 1];
                    Console.WriteLine("Current Diff is: " + Math.Round(diff,2) + " current counter "+ Units[counter - 1] + "  "+UnitsW[counter - 1]+"  OK");
                }
                else if (diff < Units[counter - 1])
                {
                  
                    counter--;
                }
                
            }


        }


        public void checkIntegers(string myPass)
        {

            bool containsInt = myPass.Any(char.IsDigit);
            //Console.WriteLine(containsInt);
            if (containsInt == true)
            {
                codes = codes + "I";

   
            }



        }

        public void checkUpperCase(string myPass)
        {
            
            int counter = 0;
            
            foreach (char i in myPass)
            {
                

                if (Char.IsUpper(i) == true)
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
        
                codes = codes + "U";
            }

        }

        public void checkLowerCase(string myPass)
        {

            int counter = 0;

            foreach (char i in myPass)
            {

                // bool resUpper = Char.IsUpper(i);

                if (Char.IsLower(i) == true)
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                codes = codes + "L";
            }

        }


        public void checkSpecialChars(string myPass)
        {

            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^A-Za-z0-9]");
            bool hasSpecial = rgx.IsMatch(myPass);
            if(hasSpecial == true)
            {
                codes = codes + "S";
            }

           
        }


        public void checkCharCount(string myPass)
        {
           
            if(myPass.Length >= 10)
            {
                codes = codes + "X";
            }
            else if(myPass.Length >= 8)
            {
                codes = codes + "Y";
            }
            else
            {
                codes = codes + "Z";
            }


        }


        public void diffvalidation()
        {
            if(ch_val < pp_val)
            {
                Console.WriteLine("ERROR! PP is greater than CH");
            }
            else if(ch_val == pp_val){
                Console.WriteLine("ZERO!!");
            }
            else
            {
                Console.WriteLine("OPERATION SUCCESS");
                
            }
           
        }
    }

    class Program
    {
        static void Main()
        {

            CashReg C1 = new CashReg();

            //C1.CalcDiff(330.00,105.00);   // Uncomment to check the answer of previous question 
            //C1.diffvalidation();          // Uncomment to check the answer of previous question 

            string pass = "";

            Console.WriteLine("Enter your Password:");
            pass = Console.ReadLine();
            C1.checkUpperCase(pass); //U
            C1.checkLowerCase(pass); //L
            C1.checkSpecialChars(pass); //S
            C1.checkIntegers(pass); //I
            C1.checkCharCount(pass); //X - Pass is more than or equals to 10  //Y - Pass is more than or equals to 8  //Z - Pass is less than 8
          
            if (C1.codes.Contains("U") && C1.codes.Contains("L") && C1.codes.Contains("S") && C1.codes.Contains("I") && C1.codes.Contains("X"))
            {
                Console.WriteLine("YOUR PASSWORD IS STRONG!!");
            }
            else if ((C1.codes.Contains("U") && C1.codes.Contains("L") && C1.codes.Contains("S") && C1.codes.Contains("Y"))){
                Console.WriteLine("YOUR PASSWORD IS MEDIUM!!");
            }
            else
            {
                Console.WriteLine("YOUR PASSWORD IS WEAK!!");
            }
           


        }





        }
}




