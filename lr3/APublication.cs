using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr3

{   // Абстрактный класс
    [Serializable]
    public abstract class APublication
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { if (name == null) { name = value; } else { throw new InvalidValueException(FieldType.Name); } }
        }

        private double cost;
        public double Cost
        {
            get { return cost; }
            set { if (cost != 0) { cost = value; } else { throw new InvalidValueException(FieldType.Cost); } }
        }

      /* private int table_of_contents_count = 0;
        public int Table_of_contents_count
        {
            get { return table_of_contents_count; }
        }

        const int max_table_of_contents = 100;

        private string[] table_of_contents = new string[max_table_of_contents];
        public string this[int i]
        {
            get
            {
                if (i >= 0 && i <= table_of_contents_count)
                {
                    return table_of_contents[i];
                }
                else
                {
                    throw new InvalidValueException(FieldType.Index);
                }
            }
            set
            {
                if (i == table_of_contents_count)
                {
                    table_of_contents[i] = value;
                    table_of_contents_count++;
                }
                else if (i >= 0 && i <= table_of_contents_count)
                {
                    table_of_contents[i] = value;
                }
                else
                {
                    throw new InvalidValueException(FieldType.Index);

                }
            }
        }
        
    */

        public APublication(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

        //виртуальный метод
        public virtual void print()
        {
            Console.WriteLine(" Количество продаж \"{0}\", {1}", name, cost);
        }

   /*   public void printPurchases()
        {
            for (int i = 0; i < table_of_contents_count; i++)
            {
                Console.WriteLine("     ГЛАВА №{0}: {1}", i + 1, this[i]);
            }
        }
        */

        public abstract void printInfo();

    }
}
