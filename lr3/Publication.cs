using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3
{
   [Serializable]
    //класс наследник от начального класса структуры
   public class Publication : APublication, Purchases
    {

        private string author;
        public string Author
        {
            get { return author; }
            set { if (author != "") author = value; }
        }

        private int purchases = 0;
        public int Purchases
        {
            get { return purchases; }
            set { if (purchases == 0) purchases = value; }
        }

       
        public Publication(string name, double cost, string author) : base(name, cost)
        {
            this.author = author;
        }

        public Publication(string name, double cost, string author, int purchases)
            : base(name, cost)
        {
            this.author = author;
            this.purchases = purchases;
        }

        public Publication(string name, string cost, string author, string purchases)
            : base(name, int.Parse(cost))
        {
            this.author = author;
            this.purchases = int.Parse(purchases);
        }
              
        new public void print()
        {
            Console.WriteLine(" Печатное издание \"{0}\"; Цена {1}; Автор: {2}, Количество проданных экземпляров: {3}", Name, Cost, Author, Purchases);
            base.print();
        }

        override public void printInfo()
        {
            Console.WriteLine(" Автор: {0}, Количество проданных экземпляров: {1}", Author, Purchases);
        }

        public void purchase()
        {
            purchases++;
        }

        public int getPurchases()
        {
            return purchases;
        }
     }
 

}
